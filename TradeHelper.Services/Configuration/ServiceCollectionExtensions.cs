using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.Extensions.Configuration;
using TradeHelper.Services.Services.Exchanges;
using TradeHelper.Services.Services.WebCore;
using TradeHelper.Services.Services.WebCore.Interfaces;

namespace TradeHelper.Services.Configuration
{
    public static class ServiceCollectionExtensions
    {
        const string BitfinexApiUrlConfigKey = "BirfinexApiUrl";

        public static void AddServices(this IServiceCollection services)
        {
            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json");
            //IConfigurationRoot configuration = builder.Build();

            services.AddScoped<IHttpClient, BaseHttpClient>();
            services.AddScoped<IBitfinexClient, BitfinexClient>();
        }
    }
}
