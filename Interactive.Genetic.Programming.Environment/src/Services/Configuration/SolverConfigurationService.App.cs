namespace Configuration;

public partial class SolverConfigurationService
{
    public bool ReadTaskFromJson
    {
        get => AppConfiguration.ReadTaskFromJson;
        set => AppConfiguration.ReadTaskFromJson = value;
    }

    public string TasksPath
    {
        get => AppConfiguration.TasksPath;
        set => AppConfiguration.TasksPath = value;
    }
}