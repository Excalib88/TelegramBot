using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Domain.Abstractions.Handlers;
using TelegramBot.Domain.Models;

namespace TelegramBot.Common.Events.Services
{
    public class OnMessage : EventHandler
    {
        public delegate void OnMessageDelegate(object sender, MessageEventArgs e);
        public event OnMessageDelegate MessageEvent;

        public override string Name => @"/message";


        public override bool Contains(Message message)
        {

            return message.Type == MessageType.Text ? message.Text.Contains(this.Name) : false;
        }

        public override void CallEvent(Message message, BotClient botClient)
        {
            botClient.OnMessage += this.onMessageEvent;
        }

        private void onMessageEvent(object sender, MessageEventArgs e)
        {

        }
    }
}
