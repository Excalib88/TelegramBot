using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;

namespace TelegramBot.Domain
{
    public static class BucketHelper
    {
        public static long GetBucket(Update update)
        {
            if (update.Message is Message message)
                return message.Chat.Id;

            if (update.ChosenInlineResult is ChosenInlineResult chosenInlineResult)
                return chosenInlineResult.From.Id;

            if (update.InlineQuery is InlineQuery inlineQuery)
                return inlineQuery.From.Id;

            if (update.CallbackQuery is CallbackQuery callbackQuery)
                return callbackQuery.Message?.Chat.Id ?? callbackQuery.From.Id;

            if (update.ChannelPost is Message channelPost)
                return channelPost.Chat.Id;

            if (update.EditedMessage is Message editedMessage)
                return editedMessage.Chat.Id;

            if (update.EditedChannelPost is Message editedChannelPost)
                return editedChannelPost.Chat.Id;

            if (update.PreCheckoutQuery is PreCheckoutQuery preCheckoutQuery)
                return preCheckoutQuery.From.Id;

            if (update.ShippingQuery is ShippingQuery shippingQuery)
                return shippingQuery.From.Id;

            // Left-over: polls
            return 0;
        }
    }
}
