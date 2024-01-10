using Database.Context;
using Database.Interfaces;

namespace Database;

public class DatabaseService : IDatabaseCreator, IDatabaseService
{
    public void EnsureCreated()
    {
        using var context = new DbCtx();
        context.Database.EnsureCreated();
    }
}