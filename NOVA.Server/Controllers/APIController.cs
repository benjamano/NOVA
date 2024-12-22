using Microsoft.AspNetCore.Mvc;
using NOVAData.DataControl;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOVAData.ViewModels;
using NOVAData;

namespace NOVAServer.Controllers
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
            IEnumerable<_Task> tasks = await _context.Tasks.ToListAsync();

            IList<TaskDTO> DTOtasks = new List<TaskDTO>();

            foreach (_Task t in tasks)
            {
                TaskDTO task = new TaskDTO()
                {
                    TaskId = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                };

                TaskStatusUpdate? tsu = await _context.TaskStatusUpdates.FirstOrDefaultAsync(s => s.TaskId == t.Id);

                if (tsu?.Status != null)
                {
                    task.Status = tsu.Status.Name;
                }
                else
                {
                    task.Status = "Not Started";
                }

                DTOtasks.Add(task);
            }

            return Ok(DTOtasks);
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

        [HttpPost("ChangeTaskStatus")]
        public async Task<IActionResult> ChangeTaskStatus(UpdateTaskStatusViewModel vm)
        {
            TaskStatusUpdate tsu = new TaskStatusUpdate
            {
                TaskId = vm.TaskId,
                StatusId = await _context.Statuses.Where(x => x.Name == vm.NewStatus).Select(x=> x.Id).FirstOrDefaultAsync()
            };

            await _context.AddAsync(tsu);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
