using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramBot.Domain.Abstractions;
using TelegramBot.Domain.Models;

namespace TelegramBot.Domain.Services
{
    public class BotService : IBotService
    {
        private BotClient _botClient;
        private readonly ILogger _logger;

        public BotService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BotService>();
        }

        public BotClient Configure()
        {
            _botClient = BotClient
                    .Create()
                    .SetSecretKeyWithProxy("secretKey", new Socks5ProxyConfiguration())
                    .Build();

            _botClient.OnMessage += _botClient_OnMessage;
            
            return _botClient;
        }

        private void _botClient_OnMessage(object sender, MessageEventArgs e)
        {
            _logger.LogInformation(e.Message.MessageId.ToString());
        }
    }
}
