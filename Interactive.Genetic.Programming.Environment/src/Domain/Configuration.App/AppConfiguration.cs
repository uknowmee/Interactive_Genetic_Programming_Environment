namespace Configuration.App;

public class AppConfiguration : IAppConfiguration
{
    public bool ReadTaskFromJson { get; set; } = true;
    
    public string TasksPath { get; set; } = "Tasks";
}