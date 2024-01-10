using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Database.Entities.Task;

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

    public DbSet<Task> Tasks { get; set; }
    public DbSet<FitnessFunction> FitnessFunctions { get; set; }
    public DbSet<Solution> Solutions { get; set; }
}