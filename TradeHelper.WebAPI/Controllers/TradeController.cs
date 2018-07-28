using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradeHelper.BLL.Managers;
using TradeHelper.BLL.Managers.Interfaces;
using TradeHelper.EntityModel.Entities;
using TradeHelper.WebApi.Models;

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
        [Route("getalltrades")]
        public async Task<IEnumerable<TradeInfoDto>> GetAllTrades()
        {
            IEnumerable<TradeInfo> trades = await this._tradeManager.GetAllTrades();
            IEnumerable<TradeInfoDto> response = AutoMapper.Mapper.Map<IEnumerable<TradeInfoDto>>(trades);
            return response;
        }
      
        [HttpPost("addOrUpdateTrade")]
        public async Task<Guid> AddOrUpdateTrade([FromBody]TradeInfoDto trade)
        {
            var entityItem = await _tradeManager.AddOrUpdate(AutoMapper.Mapper.Map<TradeInfo>(trade));
            return entityItem.Id;
        }

        [HttpDelete("remove/{id}")]
        public async Task<HttpResponseMessage> RemoveTradeItems([FromRoute] Guid id)
        {
            bool success = await _tradeManager.Remove(new List<Guid> { id });
            if (success)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}