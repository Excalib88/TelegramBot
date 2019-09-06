using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TelegramBot.Common;
using TelegramBot.Common.Swagger;

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TelegramBot.Server", Version = "v1" });
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

            // todo: need to uncomment if we will use ef core
            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    scope.ServiceProvider.GetRequiredService<DataContext>().InitDatabase();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
