﻿using MihaZupan;
using TelegramBot.Domain.FluentBuilders;
using Telegram.Bot;
using System.Collections.Generic;
using TelegramBot.Domain.Abstractions.Handlers;

namespace TelegramBot.Domain.Models
{
    public class BotClient: TelegramBotClient
    {
        public List<EventHandler> EventHandlers = new List<EventHandler>();

        public BotClient(string secretKey) : base(secretKey) { }

        public BotClient(string secretKey, HttpToSocks5Proxy proxy) : base(secretKey, proxy) { }

        public static BotClientBuilder Create()
        {
            return new BotClientBuilder();
        }
    }
}
