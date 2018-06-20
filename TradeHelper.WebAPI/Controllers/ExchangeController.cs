using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradeHelper.BLL.Common;
using TradeHelper.BLL.Managers.Interfaces;

namespace TradeHelper.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ExchangeController: Controller
    {
        private IBitfinexApiManager _bitfinexApiManager;

        public ExchangeController(IBitfinexApiManager bitfinexApi)
        {
            _bitfinexApiManager = bitfinexApi;
        }

        [HttpGet]
        [Route("status")]
        public async Task<int> PingAsync()
        {
            ExchangeStatus pingStatus = await _bitfinexApiManager.GetExchangeStatus();
            return (int) pingStatus;
        }
    }
}
