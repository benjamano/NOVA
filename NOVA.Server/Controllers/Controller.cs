using Microsoft.AspNetCore.Mvc;
using NOVA.Server.Models;
using System.Collections.Generic;

namespace NOVA.Server.Controllers
{
    [ApiController]
    [Route("NovaAPI")]
    public class Controller : ControllerBase
    {
        [HttpGet("Home")]
        public IActionResult HomePage()
        {
            return Ok("Welcome to the Nova API!");
        }
    }
}
