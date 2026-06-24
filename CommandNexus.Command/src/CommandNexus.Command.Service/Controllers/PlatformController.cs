using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CommandNexus.Command.Service.Controllers
{
    [Route("/api/c/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        public PlatformController()
        {

        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("Inbound POST Connection #CommandService!!");
            return Ok("Inbound test Platform Controller");
        }
    }
}
