﻿using fiskaltrust.ifPOS.v1;
using fiskaltrust.Middleware.Interface.Client.Shared;
using System.Threading.Tasks;

namespace fiskaltrust.Middleware.Interface.Client.Http
{
    public static class HttpPosFactory
    {
        public static async Task<IPOS> CreatePosAsync(HttpPosOptions options)
        {
            var connectionhandler = new HttpProxyConnectionHandler<IPOS>(new HttpPos(options));

            if (options.RetryPolicyOptions != null)
            {
                var retryPolicyHelper = new RetryPolicyHandler<IPOS>(options.RetryPolicyOptions, connectionhandler);
                return new PosRetryProxyClient(retryPolicyHelper);
            }
            else
            {
                return await connectionhandler.GetProxyAsync();
            }
        }
    }
}
