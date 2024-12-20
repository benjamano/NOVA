using Microsoft.AspNetCore.Mvc;
using NOVA.NOVAData.Models;
using NOVA.NOVAData.DBContext;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NOVA.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NovaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NovaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> AllTasks()
        {
            return Ok(await _context.Tasks.ToListAsync());
        }
    }
}
