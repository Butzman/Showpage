using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Communication.Controllers
{
    public class SecretController: Controller
    {
        [HttpGet]
        [Route("/secret")]
        [Authorize]
        public string Index()
        {
            return "secret message from CodersShop_Api";
        }
    }
}