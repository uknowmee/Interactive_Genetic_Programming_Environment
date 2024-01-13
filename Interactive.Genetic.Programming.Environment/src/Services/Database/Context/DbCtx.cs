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
    public DbSet<SolutionEntity> Solutions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SolutionEntity>()
            .ComplexProperty<TaskEntity>(
                solution => solution.SolvedTask,
                task =>
                {
                    task.Ignore(t => t.Id);
                }
            );

        modelBuilder.Entity<SolutionEntity>()
            .ComplexProperty<FitnessFunctionEntity>(
                solution => solution.InitialFitness,
                fitness =>
                {
                    fitness.Ignore(f => f.Id);
                }
            );
    }
}