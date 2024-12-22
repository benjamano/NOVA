using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NOVAServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult HomePage()
        {
            return Ok("Welcome to the Nova API!");
        }
    }
}
