using Microsoft.AspNetCore.Mvc;
using NOVA.Server.Models;

[ApiController]
[Route("NovaApi")]
public class NovaController : ControllerBase
{
    [HttpGet("GetAllTasks")]
    public IEnumerable<_Task> AllTasks()
    {
        return Enumerable.Range(1, 5).Select(index => new _Task
        {
            Id = index,
            Title = $"Task {index}",
            Description = $"This is a description for Task {index}",
            Status = "Pending",
            DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(index))
        }).ToArray();
    }
}
