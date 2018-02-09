using System.Collections.Generic;
using TradeHelper.Cqrs.Query.Interfaces;
using TradeHelper.Models.DTO;

namespace TradeHelper.Models.QueryResults
{
    public class GetAllTradesQueryResult: IQueryResult
    {
        public IEnumerable<TradeInfoModel> Result { get; set; }
    }
}