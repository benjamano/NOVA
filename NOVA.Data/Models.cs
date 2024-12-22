namespace NOVAData
{
    public class _Task
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateOnly DueDate { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class TaskStatusUpdate
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int StatusId { get; set; }
        public Status? Status { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
