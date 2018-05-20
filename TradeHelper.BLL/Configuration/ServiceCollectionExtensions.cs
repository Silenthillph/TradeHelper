using Microsoft.Extensions.DependencyInjection;
using TradeHelper.BLL.Managers;

namespace TradeHelper.BLL.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBll(this IServiceCollection services)
        {
            services.AddScoped<ITradeManager, TradeManager>();
        }
    }
}
