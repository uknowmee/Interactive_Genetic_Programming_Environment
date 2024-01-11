using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public class DbCtx : DbContext
{
    private const string ConnectionString = "Server=localhost;Port=5432;Database=inzDb;User Id=inz;Password=inz;";

    public DbCtx() : this(ConnectionString)
    {
    }

    public DbCtx(string connectionString)
        : base(new DbContextOptionsBuilder<DbCtx>().UseNpgsql(connectionString).Options)
    {
    }

    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<FitnessFunctionEntity> FitnessFunctions { get; set; }
    public DbSet<Solution> Solutions { get; set; }
}