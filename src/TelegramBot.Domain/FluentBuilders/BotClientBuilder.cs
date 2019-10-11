using MihaZupan;
using SharpCollections.Generic;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.Domain.Models;

namespace TelegramBot.Domain.FluentBuilders
{
    public class BotClientBuilder
    {
        private BotClient botClient;

        public BotClientBuilder SetSecretKey(string secretKey)
        {
            botClient = new BotClient(secretKey);
            
            return this;
        }

        // optional
        public BotClientBuilder SetSecretKeyWithProxy(string secretKey, Socks5ProxyConfiguration proxyConfiguration)
        {
            var proxy = new HttpToSocks5Proxy(
                proxyConfiguration.Host, 
                proxyConfiguration.Port);

            botClient = new BotClient(secretKey, proxy);

            return this;
        }

        public BotClientBuilder SetOnMessageCallback()
        {
            //- todo: need refactoring eventHandlers
            return this;
        }

        public BotClientBuilder Build()
        {
            //botClient.EventHandlers.Add(new OnMessage());
            //botClient.OnMessage += BotClient_OnMessage;
            //botClient.StartReceiving();

            return this;
        }

        public static implicit operator BotClient(BotClientBuilder botClientBuilder)
        {
            return botClientBuilder.botClient;
        }
    }
}
