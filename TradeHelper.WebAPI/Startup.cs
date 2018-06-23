using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeHelper.BLL.Configuration;
using TradeHelper.WebApi.Core.Configurations;
using TradeHelper.WebApi.Mappings;

namespace TradeHelper.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddCors();
            services.AddMvc();
            services.AddTradeHelperDbContext(connectionString);
            services.AddUnitOfWork();
            services.AddScoped();
            services.AddBll();

            MappingConfiguration.Configure();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              IContextConfiguration context)
        {
            context.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            app.UseMvc();
            app.UseStaticFiles();  
        }
    }
}
