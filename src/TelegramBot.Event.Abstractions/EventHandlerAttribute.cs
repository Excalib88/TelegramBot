using System;

namespace TelegramBot.Event.Abstractions
{
    public sealed class EventHandlerAttribute : Attribute
    {
        public string Name { get; }

        public EventHandlerAttribute(string name)
        {
            Name = name;
        }
    }
}
