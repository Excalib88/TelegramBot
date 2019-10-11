using System;
using Telegram.Bot.Types;
using TelegramBot.Domain.Models;

namespace TelegramBot.Domain.Abstractions.Handlers
{
    public abstract class EventHandler : IEventHandler
    {
        public abstract string Name { get; }

        public abstract bool Contains(Message message);

        public abstract void CallEvent(Message message, BotClient botClient);
    }
}
