using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOVAData.ViewModels
{
    public class CreateTaskViewModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateTime DueDate { get; set; }
    }
    public class UpdateTaskStatusViewModel
    {
        public int TaskId { get; set; }
        public required string NewStatus { get; set; }
    }

}
