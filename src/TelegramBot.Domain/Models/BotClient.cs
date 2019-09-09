using MihaZupan;
using Telegram.Bot;
using TelegramBot.Domain.FluentBuilders;

namespace TelegramBot.Domain.Models
{
    public class BotClient: TelegramBotClient
    {
        public BotClient(string secretKey) : base(secretKey) { }
        public BotClient(string secretKey, HttpToSocks5Proxy proxy) : base(secretKey, proxy) { }

        public static BotClientBuilder Create()
        {
            return new BotClientBuilder();
        }
    }
}
