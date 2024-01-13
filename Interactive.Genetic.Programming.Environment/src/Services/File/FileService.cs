using System.Text.Json;
using File.Interfaces;
using Shared;

namespace File;

public class FileService : IFileService
{
    public object? ReadFromJson<T>(string path)
    {
        try
        {
            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException($"File not found: {path}");
            }

            var jsonContent = System.IO.File.ReadAllText(path);

            return JsonSerializer.Deserialize<T>(jsonContent)
                   ?? throw new JsonException($"Failed to deserialize JSON content from file: {path}");
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public void SaveAsJson<T>(string json, string destinationPath) where T : IPrettySerializable
    {
        var obj = JsonSerializer.Deserialize<T>(json) ?? throw new Exception("Failed to deserialize JSON content");
        SaveAsJson(obj, destinationPath);
    }

    public void SaveAsJson<T>(T serializable, string destinationPath) where T : IPrettySerializable
    {
        var dirPath = Path.GetDirectoryName(destinationPath) ?? throw new Exception("Directory path is null");
        
        if (Directory.Exists(dirPath) is false)
        {
            Directory.CreateDirectory(dirPath);
        }
        
        System.IO.File.WriteAllText(destinationPath, serializable.JsonToFile);
    }

    public object? ReadFromCsv<T>(string path)
    {
        throw new NotImplementedException();
    }

    public void DeleteAt(string path)
    {
        System.IO.File.Delete(path);
    }

    public bool DoesFileExist(string path)
    {
        return System.IO.File.Exists(path);
    }
}