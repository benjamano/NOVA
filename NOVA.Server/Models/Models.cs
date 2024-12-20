namespace NOVA.Server.Models
{
    public class _Task
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateOnly DueDate { get; set; }
    }
}
