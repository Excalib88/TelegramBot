using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramBot.Domain.Abstractions;
using TelegramBot.Domain.Models;

namespace TelegramBot.Domain.Services
{
    public class BotService : IBotService
    {
        private Socks5ProxyConfiguration _socks5Proxy;

        private BotClient _botClient;
        private readonly ILogger _logger;

        public BotService(IOptions<Socks5ProxyConfiguration> options, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BotService>();
            _socks5Proxy = new Socks5ProxyConfiguration { Host = "45.77.9.199", Port = 1080 };//options.Value;
        }

        public BotClient Configure()
        {
            _botClient = BotClient
                    .Create()
                    .SetSecretKeyWithProxy("983922268:AAGxXiplHabEGFUYv92pKe9VjogbPW2793I", _socks5Proxy)
                    .SetOnMessageCallback()
                    .Build();

            return _botClient;
        }

        public async Task<BotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                _logger.LogInformation("Bot client was configured");
                return _botClient;

            }
            // Configure BotClient
            this.Configure();

            await _botClient.GetUpdatesAsync();
            return _botClient;
        }
    }
}
