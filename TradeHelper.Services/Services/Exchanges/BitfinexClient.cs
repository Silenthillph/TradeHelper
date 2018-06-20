using System.Threading.Tasks;
using TradeHelper.Services.Extensions;
using TradeHelper.Services.Helpers;
using TradeHelper.Services.Services.WebCore.Interfaces;

namespace TradeHelper.Services.Services.Exchanges
{
    public class BitfinexClient: IBitfinexClient
    {
        private IHttpClient _httpClient;

        public BitfinexClient(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> PingAsync()
        {
            var a2s = await GetAsync<int[]>(BitfinexApiUrls.Ping.ToString());
            return 1;
                                                                                                                                                                                           
        }

        private Task<T> GetAsync<T>(string uri)
        {
            return _httpClient.GetAsJsonAsync<T>(uri);
        }

        //private void ConfigureHttpClient(ApiKeyPair apiKeyPair)
        //{
        //    if (!string.IsNullOrWhiteSpace(apiKeyPair.PublicKey) &&
        //        !string.IsNullOrWhiteSpace(apiKeyPair.SecretKey))
        //    {
        //        Dictionary<string, string> defaultHeaders = new Dictionary<string, string> { { X_SIGNATURE, CreateHeaderSignature(apiKeyPair) } };
        //        _httpClient.Configure(defaultHeaders: defaultHeaders);
        //    }
        //}

        //private string CreateHeaderSignature(ApiKeyPair apiKeyPair)
        //{
        //    int timestamp = (int)(DateTime.UtcNow - EpochUtc).TotalSeconds;
        //    string payload = $"{timestamp}.{apiKeyPair.PublicKey}";
        //    HMACSHA256 sigHasher = new HMACSHA256(Encoding.ASCII.GetBytes(apiKeyPair.SecretKey));
        //    byte[] digestValueBytes = sigHasher.ComputeHash(Encoding.ASCII.GetBytes(payload));
        //    string digestValueHex = BitConverter.ToString(digestValueBytes)
        //                                        .Replace(DASH, string.Empty)
        //                                        .ToLower();
        //    return $"{payload}.{digestValueHex}";
        //}        
    }
}
