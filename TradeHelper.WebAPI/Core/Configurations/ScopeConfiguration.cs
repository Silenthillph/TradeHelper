using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TradeHelper.EntityModel;
using TradeHelper.EntityModel.UnitOfWork;

namespace TradeHelper.WebApi.Core.Configurations
{
    public static class ScopeConfiguration
    {
        public static void AddTradeHelperDbContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<TradeHelperContext>(options => options.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, TradeHelperContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IContextConfiguration, ContextConfiguration>();
        }
    }
}
