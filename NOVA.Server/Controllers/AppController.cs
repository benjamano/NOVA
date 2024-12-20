using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NOVA.Server.Controllers
{
    [ApiController]
    [Route("NovaAPI")]
    public class AppController : ControllerBase
    {
        [HttpGet("Home")]
        public IActionResult HomePage()
        {
            return Ok("Welcome to the Nova API!");
        }
    }
}
