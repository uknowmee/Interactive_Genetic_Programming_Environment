using Configuration.App;
using Database.Context;
using Database.Entities;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class DatabaseService : IDatabaseCreator, IFitnessDatabaseService, ITaskDatabaseService
{
    private readonly DbContextOptions _options;
    private readonly string _sqliteDir;
    
    public DatabaseService(IAppConfiguration appConfiguration)
    {
        _options = appConfiguration.Sqlite 
            ? new DbContextOptionsBuilder<DbCtx>().UseSqlite(appConfiguration.ConnectionString).Options 
            : new DbContextOptionsBuilder<DbCtx>().UseNpgsql(appConfiguration.ConnectionString).Options;
        
        _sqliteDir = Path.GetDirectoryName(appConfiguration.DbPath) ?? throw new Exception("Directory db is null");
    }
    
    public void EnsureCreated()
    {
        if (Directory.Exists(_sqliteDir) is false)
        {
            Directory.CreateDirectory(_sqliteDir);
        }
        
        using var context = new DbCtx(_options);
        context.Database.EnsureCreated();
    }

    public void Create(TaskEntity task)
    {
        using var context = new DbCtx(_options);
        context.Tasks.Add(task);
        context.SaveChanges();
    }

    public void Delete(TaskEntity task)
    {
        using var context = new DbCtx(_options);
        context.Tasks.Remove(task);
        context.SaveChanges();
    }

    public void Delete(FitnessFunctionEntity fitness)
    {
        using var context = new DbCtx(_options);
        context.FitnessFunctions.Remove(fitness);
        context.SaveChanges();
    }

    IEnumerable<TaskEntity> IDatabaseService<TaskEntity>.FetchAll()
    {
        return FetchAll<TaskEntity>();
    }

    public void Create(FitnessFunctionEntity fitness)
    {
        using var context = new DbCtx(_options);
        context.FitnessFunctions.Add(fitness);
        context.SaveChanges();
    }

    IEnumerable<FitnessFunctionEntity> IDatabaseService<FitnessFunctionEntity>.FetchAll()
    {
        return FetchAll<FitnessFunctionEntity>();
    }

    private List<T> FetchAll<T>() where T : class
    {
        using var context = new DbCtx(_options);
        return context.Set<T>().ToList();
    }
}