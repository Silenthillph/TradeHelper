using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeHelper.EntityModel.Entities;

namespace TradeHelper.BLL.Managers.Interfaces
{
    public interface ITradeManager
    {
        Task<IEnumerable<TradeInfo>> GetAllTrades();
        Task<bool> Remove(List<Guid> items);
        Task<TradeInfo> AddOrUpdate(TradeInfo tradeInfo);
    }
}
