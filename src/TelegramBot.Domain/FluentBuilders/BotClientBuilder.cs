using MihaZupan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TelegramBot.Domain.Models;

namespace TelegramBot.Domain.FluentBuilders
{
    public class BotClientBuilder
    {
        private BotClient _botClient;

        public BotClientBuilder SetSecretKey(string secretKey)
        {
            _botClient = new BotClient(secretKey);
            return this;
        }

        // optional
        public BotClientBuilder SetSecretKeyWithProxy(string secretKey, Socks5ProxyConfiguration proxyConfiguration)
        {
            var proxy = new HttpToSocks5Proxy(
                proxyConfiguration.Host, 
                proxyConfiguration.Port, 
                proxyConfiguration.Username, 
                proxyConfiguration.Password);

            _botClient = new BotClient(secretKey, proxy);

            return this;
        }

        public BotClientBuilder Build()
        {
            _botClient.StartReceiving();

            return this;
        }

        public static implicit operator BotClient(BotClientBuilder botClientBuilder)
        {
            return botClientBuilder._botClient;
        }
    }
}
