using System.Threading.Tasks;

namespace TradeHelper.Services.Services.Exchanges
{
    public interface IBitfinexClient
    {
        Task<int> PingAsync();
    }
}
