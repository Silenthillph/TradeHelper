using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradeHelper.Web.Cqrs.Command.Interfaces;
using TradeHelper.Web.Cqrs.Query.Interfaces;
using TradeHelper.Web.Models.Commands;
using TradeHelper.Web.Models.DTO;
using TradeHelper.Web.Models.Queries;
using TradeHelper.Web.Models.QueryResults;

namespace TradeHelper.Controllers.Api
{
    public class TradeController: Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public TradeController(IQueryDispatcher dispatcher, ICommandDispatcher commandDispatcher)
        {
            this._queryDispatcher = dispatcher;
            this._commandDispatcher = commandDispatcher;
        }
        
        [HttpGet]
        public async Task<IEnumerable<TradeInfoModel>> GetAllTrades()
        {
            var queryResult = await this._queryDispatcher.Dispatch<CommonQuery, GetAllTradesQueryResult>(new CommonQuery());

            return queryResult.Result;
        }


        
        [HttpPost]
        public async Task<HttpResponseMessage> AddOrUpdateTrade([FromBody]TradeInfoModel trade)
        {
            var commandResult = await this._commandDispatcher.Dispatch(new AddOrUpdateTradeInfoCommand
                                                                     {
                                                                         Model = trade
                                                                     });
            if (commandResult.Success)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> RemoveTradeItems([FromRoute] List<Guid> items)
        {
            var commandResult = await this._commandDispatcher.Dispatch(new RemoveTradeInfoCommand {ItemsToRemove = items});
            if (commandResult.Success)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}