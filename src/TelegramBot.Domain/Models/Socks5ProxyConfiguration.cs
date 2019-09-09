using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Domain.Models
{
    public class Socks5ProxyConfiguration
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
