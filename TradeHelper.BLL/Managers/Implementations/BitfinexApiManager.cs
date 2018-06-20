using System.Threading.Tasks;
using TradeHelper.BLL.Common;
using TradeHelper.BLL.Managers.Interfaces;
using TradeHelper.Services.Services.Exchanges;

namespace TradeHelper.BLL.Managers.Implementations
{
    class BitfinexApiManager: IBitfinexApiManager
    {
        private IBitfinexClient _bitfinexClient;

        public BitfinexApiManager(IBitfinexClient client)
        {
            _bitfinexClient = client;
        }

        public async Task<ExchangeStatus> GetExchangeStatus()
        {
            int bitfinexStatus = await _bitfinexClient.PingAsync();
            return (ExchangeStatus) bitfinexStatus;
        }
    }
}
