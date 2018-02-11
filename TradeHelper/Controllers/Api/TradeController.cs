using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using TradeHelper.Cqrs.Command.Interfaces;
using TradeHelper.Cqrs.Query.Interfaces;
using TradeHelper.Models.Commands;
using TradeHelper.Models.DTO;
using TradeHelper.Models.Queries;
using TradeHelper.Models.QueryResults;

namespace TradeHelper.Controllers.Api
{
    public class TradeController: ApiController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public TradeController(IQueryDispatcher dispatcher, ICommandDispatcher commandDispatcher)
        {
            this._queryDispatcher = dispatcher;
            this._commandDispatcher = commandDispatcher;
        }
        
        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<TradeInfoModel>> GetAllTrades()
        {
            var queryResult = await this._queryDispatcher.Dispatch<CommonQuery, GetAllTradesQueryResult>(new CommonQuery());

            return queryResult.Result;
        }


        
        [System.Web.Http.HttpPost]
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

        [System.Web.Http.HttpDelete]
        public async Task<HttpResponseMessage> RemoveTradeItems([FromUri] List<int> items)
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