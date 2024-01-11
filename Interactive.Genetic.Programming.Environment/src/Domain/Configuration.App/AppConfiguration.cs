namespace Configuration.App;

public class AppConfiguration : IAppConfiguration
{
    private const string DbFolderName = "db";
    private const string TasksFolderName = "app_tasks";
    private const string SolutionsFolderName = "app_solutions";
    private string InitialDirectory => ReadTaskFromJson ? "tasks" : "tasks_csv";

#if DEBUG
    public string InitialDirectoryPath => Path.Combine(GoFiveUpFromCurrentDir(), InitialDirectory);
    public string TasksPath => Path.Combine(GoFiveUpFromCurrentDir(), TasksFolderName);
    public string SolutionsPath => Path.Combine(GoFiveUpFromCurrentDir(), TasksFolderName);
    public string DbPath => Path.Combine(GoFiveUpFromCurrentDir(), DbFolderName, "inzDb.db");
#else
    public string InitialDirectoryPath { get; } = @"C:\";
    public string TasksPath => Path.Combine(Directory.GetCurrentDirectory(), TasksFolderName);
    public string SolutionsPath => Path.Combine(Directory.GetCurrentDirectory(), TasksFolderName);
    public string DbPath => Path.Combine(Directory.GetCurrentDirectory(), DbFolderName, "inzDb.db");
#endif

    public bool ReadTaskFromJson { get; set; } = true;
    public bool Sqlite { get; set; } = true;
    public string TaskOpener { get; set; } = "notepad.exe";
    public string ConnectionString => Sqlite
        ? $"Data Source={DbPath}" 
        : "Server=localhost;Port=5432;Database=inzDb;User Id=inz;Password=inz;";

    private static string GoFiveUpFromCurrentDir()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var fiveUp = Path.Combine(currentDir, "..", "..", "..", "..", "..");
        return Path.GetFullPath(fiveUp);
    }
}