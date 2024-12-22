using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NOVAData.DataControl;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=NovaDB;Integrated Security=True;Multiple Active Result Sets=True");

        return new AppDbContext(optionsBuilder.Options);
    }
}
