using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TelegramBot.Common;
using TelegramBot.Domain.Models;

namespace TelegramBot.Server.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        private Socks5ProxyConfiguration _proxyConfiguration;

        public BotController(IOptions<Socks5ProxyConfiguration> options)
        {
            _proxyConfiguration = options.Value;
        }

        [HttpGet("getproxy")]
        public ApiResponse<Socks5ProxyConfiguration> GetProxy()
        {
            return ApiResponse.Ok(_proxyConfiguration);
        }
    }
}
