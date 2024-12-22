using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using NOVAData;
using System.Threading.Tasks.Sources;

namespace NOVAData.DataControl
{
    public class AppDbContext : DbContext
    {
        public DbSet<_Task> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TaskStatusUpdate> TaskStatusUpdates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
