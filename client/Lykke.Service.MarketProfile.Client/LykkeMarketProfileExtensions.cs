// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Lykke.Service.MarketProfile.Client
{
    using Lykke.Service;
    using Lykke.Service.MarketProfile;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for LykkeMarketProfile.
    /// </summary>
    public static partial class LykkeMarketProfileExtensions
    {
            /// <summary>
            /// Checks service is alive
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IsAliveResponse ApiIsAliveGet(this ILykkeMarketProfile operations)
            {
                return operations.ApiIsAliveGetAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Checks service is alive
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IsAliveResponse> ApiIsAliveGetAsync(this ILykkeMarketProfile operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiIsAliveGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<AssetPairModel> ApiMarketProfileGet(this ILykkeMarketProfile operations)
            {
                return operations.ApiMarketProfileGetAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<AssetPairModel>> ApiMarketProfileGetAsync(this ILykkeMarketProfile operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiMarketProfileGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='pairCode'>
            /// </param>
            public static object ApiMarketProfileByPairCodeGet(this ILykkeMarketProfile operations, string pairCode)
            {
                return operations.ApiMarketProfileByPairCodeGetAsync(pairCode).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='pairCode'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> ApiMarketProfileByPairCodeGetAsync(this ILykkeMarketProfile operations, string pairCode, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiMarketProfileByPairCodeGetWithHttpMessagesAsync(pairCode, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}