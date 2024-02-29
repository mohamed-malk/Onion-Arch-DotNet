using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    { }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}



