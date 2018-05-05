using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TradeHelper.EntityModel;
using TradeHelper.EntityModel.UnitOfWork;

namespace TradeHelper.Web.Core.Configurations
{
    public static class ScopeConfiguration
    {
        public static IServiceCollection AddTradeHelperDbContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<TradeHelperContext>(options => options.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IContextConfiguration, ContextConfiguration>();
        }
    }
}
