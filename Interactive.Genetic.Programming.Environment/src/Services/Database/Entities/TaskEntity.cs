namespace Database.Entities;

public class TaskEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Json { get; set; }

    public string FromPath { get; set; }
    
    public string Path { get; set; }

    [Obsolete("Only for EF")]
    public TaskEntity()
    {
    }
    
    public TaskEntity(string taskName, string taskFromPath, string path, string json)
    {
        Name = taskName;
        FromPath = taskFromPath;
        Path = path;
        Json = json;
    }
    
    public override string ToString()
    {
        return Name;
    }
}