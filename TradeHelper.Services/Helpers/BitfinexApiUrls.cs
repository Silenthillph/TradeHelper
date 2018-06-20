using System;

namespace TradeHelper.Services.Helpers
{
    public static class BitfinexApiUrls
    {
        private const string BASE_URL = "https://api.bitfinex.com/v2";
        private static readonly Uri ApiEndPoint = new Uri(BASE_URL);

        public static string Ping
        {
            get
            {
                return $"{ApiEndPoint}/platform/status";
            }
        }
    }
}
