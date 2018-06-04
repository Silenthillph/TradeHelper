using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradeHelper.BLL.Managers;
using TradeHelper.EntityModel.Entities;
using TradeHelper.Web.Models;

namespace TradeHelper.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TradeController: Controller
    {

        private readonly ITradeManager _tradeManager;

        public TradeController(ITradeManager tradeManager)
        {
            _tradeManager = tradeManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<TradeInfoModel>> GetAllTrades()
        {
            IEnumerable<TradeInfo> trades = await this._tradeManager.GetAllTrades();
            IEnumerable<TradeInfoModel> response = AutoMapper.Mapper.Map<IEnumerable<TradeInfoModel>>(trades);
            return response;
        }
       
        [HttpPost]
        public async Task<HttpResponseMessage> AddOrUpdateTrade([FromBody]TradeInfoModel trade)
        {

            TradeInfo tradeInfo = await _tradeManager.AddOrUpdate(AutoMapper.Mapper.Map<TradeInfo>(trade));
            if (tradeInfo != null)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> RemoveTradeItems([FromRoute] List<Guid> items)
        {
            bool success = await _tradeManager.Remove(items);
            if (success)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}