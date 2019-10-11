using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBot.Common.Events.Services;
using TelegramBot.Domain.Abstractions;
using TelegramBot.Domain.Services;
using TelegramBot.Event.Abstractions;

namespace TelegramBot.Common
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCallbackServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IBotService, BotService>();
        }
    }
}
