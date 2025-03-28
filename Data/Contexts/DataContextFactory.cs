using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\EC Webbutveckling\5. ASP.NET\AlphaDashboard\Data\Database\local_db.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True");

        return new AppDbContext(optionsBuilder.Options);
    }
}