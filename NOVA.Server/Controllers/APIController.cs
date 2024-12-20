using Microsoft.AspNetCore.Mvc;
using NOVA.NOVAData.Models;
using NOVA.NOVAData.DBContext;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOVAData.ViewModels;

namespace NOVA.Server.Controllers
{
    [ApiController]
    [Route("NovaAPI")]
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

        [HttpPost("AddNewTask")]
        public async Task<IActionResult> AddNewTask(CreateTaskViewModel vm)
        {
            _Task t = new _Task()
            {
                Title = vm.Title,
                Description = vm.Description,
                DueDate = DateOnly.FromDateTime(vm.DueDate),
                Status = vm.Status
            };

            await _context.AddAsync(t);

            await _context.SaveChangesAsync();

            return Ok(t);
        }
    }
}
