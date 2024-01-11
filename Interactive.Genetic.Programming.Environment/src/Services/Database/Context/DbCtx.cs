using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public class DbCtx : DbContext
{
    public DbCtx(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<FitnessFunctionEntity> FitnessFunctions { get; set; }
    public DbSet<Solution> Solutions { get; set; }
}