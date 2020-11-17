using Microsoft.AspNetCore.Mvc;

namespace Api.Communication.Controllers
{
    public class SecretController: Controller
    {
        [HttpGet]
        [Route("/secret")]
        public string Index()
        {
            return "Hallo!!";
        }
    }
}