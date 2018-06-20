using System.Threading.Tasks;
using TradeHelper.BLL.Common;

namespace TradeHelper.BLL.Managers.Interfaces
{
    public interface IBitfinexApiManager
    {
        Task<ExchangeStatus> GetExchangeStatus();
    }
}
