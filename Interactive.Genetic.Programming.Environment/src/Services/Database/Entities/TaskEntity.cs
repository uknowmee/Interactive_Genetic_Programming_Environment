using System.ComponentModel.DataAnnotations.Schema;
using Task = Shared.Task;

namespace Database.Entities;

[ComplexType]
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

public static partial class MappingExtensions
{
    public static TaskEntity SolutionToEntity(this Task task, string solutionPath)
    {
        return new TaskEntity(task.TaskName, string.Empty, solutionPath, task.Json);
    }
    
    public static TaskEntity TaskToEntity(this Task task, string fromPath, string taskPath)
    {
        return new TaskEntity(task.TaskName, fromPath, taskPath, task.Json);
    }
}