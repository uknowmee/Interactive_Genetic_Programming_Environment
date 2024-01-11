namespace Configuration.App;

public interface IAppConfiguration
{
    public bool ReadTaskFromJson { get; set; }
    string TasksPath { get; set; }
}