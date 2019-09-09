using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using TelegramBot.Domain.Models;

namespace TelegramBot.Domain.Abstractions
{
    public interface IBotService
    {
        BotClient Configure();
    }
}
