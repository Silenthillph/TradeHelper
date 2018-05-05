using System.Collections.Generic;
using TradeHelper.Web.Cqrs.Query.Interfaces;
using TradeHelper.Web.Models.DTO;

namespace TradeHelper.Web.Models.QueryResults
{
    public class GetAllTradesQueryResult: IQueryResult
    {
        public IEnumerable<TradeInfoModel> Result { get; set; }
    }
}