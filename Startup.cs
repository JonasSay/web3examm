using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using ConsoleApi.Models;
using ConsoleApi.Services;
using GameApi.Models;
using GameApi.Services;
using Microsoft.Extensions.Options;

namespace web3_h20_10036
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
            services.AddControllers();

            services.AddCors(
                options => { 
                    options.AddPolicy("AllowAll",
                        builder => builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                    );
                }
            );


            services.Configure<ConsoleDatabaseSettings>(
                Configuration.GetSection( nameof(ConsoleDatabaseSettings)) 
            );
            services.Configure<GameDatabaseSettings>(
                Configuration.GetSection( nameof(GameDatabaseSettings))
            );

            services.AddSingleton<IConsoleDatabaseSettings>(
                sp => sp.GetRequiredService<IOptions<ConsoleDatabaseSettings>>().Value
            );
            services.AddSingleton<IGameDatabaseSettings>(
                sp => sp.GetRequiredService<IOptions<GameDatabaseSettings>>().Value
            );

            services.AddSingleton<ConsolesService>();
            services.AddSingleton<GamesService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseStaticFiles();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
