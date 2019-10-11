using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TelegramBot.Common;
using TelegramBot.Domain.Abstractions;
using TelegramBot.Domain.Models;

namespace TelegramBot.Server.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        private Socks5ProxyConfiguration _proxyConfiguration;
        private readonly IBotService _botService;
        
        public BotController(IOptions<Socks5ProxyConfiguration> options, IBotService botService)
        {
            _proxyConfiguration = options.Value;
            _botService = botService;
        }

        [HttpGet("start")]
        public void Init()
        {
            //return _botService.GetBotClientAsync().Wait();
        }

        [HttpGet("getproxy")]
        public ApiResponse<Socks5ProxyConfiguration> GetProxy()
        {
            return ApiResponse.Ok(_proxyConfiguration);
        }
    }
}
