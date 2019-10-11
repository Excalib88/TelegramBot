using Telegram.Bot.Types;
using TelegramBot.Domain.Models;

namespace TelegramBot.Domain.Abstractions.Handlers
{
    public interface IEventHandler
    {
        bool Contains(Message message);
        void CallEvent(Message message, BotClient botClient);
    }
}
