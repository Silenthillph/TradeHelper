using Microsoft.Extensions.DependencyInjection;
using TradeHelper.BLL.Managers;
using TradeHelper.BLL.Managers.Implementations;
using TradeHelper.BLL.Managers.Interfaces;
using TradeHelper.Services.Configuration;

namespace TradeHelper.BLL.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBll(this IServiceCollection services)
        {
            services.AddServices();
            services.AddScoped<IBitfinexApiManager, BitfinexApiManager>();
            services.AddScoped<ITradeManager, TradeManager>();
        }
    }
}
