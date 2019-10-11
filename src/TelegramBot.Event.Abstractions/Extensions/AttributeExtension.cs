using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Event.Abstractions
{
    public static class AttributeExtension
    {
        public static string GetEventName(this Type type)
        {
            var attribute =
                (EventHandlerAttribute)Attribute.GetCustomAttribute(type, typeof(EventHandlerAttribute));
            return attribute != null ? attribute.Name : string.Empty;
        }
    }
}
