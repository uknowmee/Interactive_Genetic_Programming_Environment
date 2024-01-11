namespace Configuration.App;

public interface IAppConfiguration
{
    string TasksPath { get; }
    string InitialDirectoryPath { get; }
    string ConnectionString { get; }
    string DbPath { get; }
    public bool ReadTaskFromJson { get; set; }
    string TaskOpener { get; set; }
    public bool Sqlite { get; set; }
}