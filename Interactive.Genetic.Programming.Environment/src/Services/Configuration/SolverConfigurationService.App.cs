namespace Configuration;

public partial class SolverConfigurationService
{
    public string TasksPath => AppConfiguration.TasksPath;

    public string InitialDirectoryPath => AppConfiguration.InitialDirectoryPath;
    public string ConnectionString => AppConfiguration.ConnectionString;
    public string DbPath => AppConfiguration.DbPath;

    public bool ReadTaskFromJson
    {
        get => AppConfiguration.ReadTaskFromJson;
        set => AppConfiguration.ReadTaskFromJson = value;
    }

    public string TaskOpener
    {
        get => AppConfiguration.TaskOpener;
        set => AppConfiguration.TaskOpener = value;
    }

    public bool Sqlite
    {
        get => AppConfiguration.Sqlite;
        set => AppConfiguration.Sqlite = value;
    }
}