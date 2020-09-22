using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Api.Communication.Controllers
{
    public class SecretController: Controller
    {
        private readonly ILogger<SecretController> _logger;

        public SecretController(ILogger<SecretController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("/secret")]
        [Authorize]
        public string Index()
        {
            var claims = User.Claims;
            var userId = claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier)?.Value;
            return "UserId: "+ userId;
        }
    }
}