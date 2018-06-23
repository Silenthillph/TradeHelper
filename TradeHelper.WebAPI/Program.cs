using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TradeHelper.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:49820/")
                .Build();
    }
}
