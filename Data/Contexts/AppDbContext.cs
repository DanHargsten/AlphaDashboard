using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<ProjectEntity> Projects { get; set; } = null!;
}