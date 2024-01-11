using Database.Context;
using Database.Entities;
using Database.Interfaces;

namespace Database;

public class DatabaseService : IDatabaseCreator, IFitnessDatabaseService, ITaskDatabaseService
{
    public void EnsureCreated()
    {
        using var context = new DbCtx();
        context.Database.EnsureCreated();
    }

    public void Create(TaskEntity task)
    {
        using var context = new DbCtx();
        context.Tasks.Add(task);
        context.SaveChanges();
    }

    public void Delete(TaskEntity task)
    {
        using var context = new DbCtx();
        context.Tasks.Remove(task);
        context.SaveChanges();
    }

    public void Delete(FitnessFunctionEntity fitness)
    {
        using var context = new DbCtx();
        context.FitnessFunctions.Remove(fitness);
        context.SaveChanges();
    }

    IEnumerable<TaskEntity> IDatabaseService<TaskEntity>.FetchAll()
    {
        return FetchAll<TaskEntity>();
    }

    public void Create(FitnessFunctionEntity fitness)
    {
        using var context = new DbCtx();
        context.FitnessFunctions.Add(fitness);
        context.SaveChanges();
    }

    IEnumerable<FitnessFunctionEntity> IDatabaseService<FitnessFunctionEntity>.FetchAll()
    {
        return FetchAll<FitnessFunctionEntity>();
    }

    private static IEnumerable<T> FetchAll<T>() where T : class
    {
        using var context = new DbCtx();
        return context.Set<T>().ToList();
    }
}