using LifeBoat_API.Hubs;
using LifeBoat_API.Models;
using LifeBoat_API.Utils;

namespace LifeBoat_API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) 
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();
            services.AddControllers();
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app) 
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<InfoHub>("/info");
            });
        }
    }
}
