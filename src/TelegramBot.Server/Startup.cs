using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TelegramBot.Common;
using TelegramBot.Common.Swagger;
using TelegramBot.Domain.Models;

namespace TelegramBot.Server
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();

            services.Configure<Socks5ProxyConfiguration>(
                _configuration.GetSection("Socks5ProxyConfiguration"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TelegramBot.Server", Version = "v1"
                });

                c.DocumentFilter<EnumDescriptionFilter>();
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            app.Use(async (context, func) =>
            {
                logger.LogInformation("Http Request {HttpContext}");
                await func();
            });

            app.UseStaticFiles();
            app.UseSwagger(_configuration);
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
