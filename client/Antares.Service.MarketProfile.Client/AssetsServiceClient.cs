﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Lykke.Job.MarketProfile.Contract;
using Lykke.Job.MarketProfile.NoSql.Models;
using Lykke.Service.MarketProfile.Client;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataReader;

namespace Antares.Service.MarketProfile.Client
{
    public partial class AssetsServiceClient : IAssetPairsClient, IDisposable
    {
        private readonly MyNoSqlTcpClient _myNoSqlClient;

        private readonly IMyNoSqlServerDataReader<AssetPairPriceNoSql> _readerAssetPairNoSql;
        private readonly ILykkeMarketProfile _httpClient;

        public AssetsServiceClient(
            string myNoSqlServerReaderHostPort,
            string marketServiceHttpApiUrl)
        {
            var host = Environment.GetEnvironmentVariable("HOST") ?? Environment.MachineName;
            _httpClient = new LykkeMarketProfile(new Uri(marketServiceHttpApiUrl));

            _myNoSqlClient = new MyNoSqlTcpClient(() => myNoSqlServerReaderHostPort, host);

            _readerAssetPairNoSql = new MyNoSqlReadRepository<AssetPairPriceNoSql>(_myNoSqlClient, AssetPairPriceNoSql.TableName);
        }

        public IAssetPairsClient AssetPairs => this;

        public ILykkeMarketProfile HttpClient => _httpClient;

        public void Start()
        {
            _myNoSqlClient.Start();

            var sw = new Stopwatch();
            sw.Start();
            var iteration = 0;
            while (iteration < 100)
            {
                iteration++;
                if (AssetPairs.GetAll().Count > 0)
                    break;

                Thread.Sleep(100);
            }
            sw.Stop();
            Console.WriteLine($"AssetService client is started. Wait time: {sw.ElapsedMilliseconds} ms");
        }

        public void Dispose()
        {
            _myNoSqlClient.Stop();
        }

        IAssetPair IAssetPairsClient.Get(string id)
        {
            try
            {
                var data = _readerAssetPairNoSql.Get(
                    AssetPairPriceNoSql.GeneratePartitionKey(),
                    AssetPairPriceNoSql.GenerateRowKey(id));

                return data?.AssetPair;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot read from MyNoSQL. Table: ${AssetPairPriceNoSql.TableName}, " +
                                  $"PK: {AssetPairPriceNoSql.GeneratePartitionKey()}, " +
                                  $"RK: {AssetPairPriceNoSql.GenerateRowKey(id)}, Ex: {ex}");
                throw;
            }
        }

        List<IAssetPair> IAssetPairsClient.GetAll()
        {
            try
            {
                var data = _readerAssetPairNoSql.Get();

                return data.Select(e => (IAssetPair)e.AssetPair).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot read from MyNoSQL. Table: ${AssetPairPriceNoSql.TableName}, Ex: {ex}");
                throw;
            }
        }
    }
}