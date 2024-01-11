using System.Text.Json;
using File.Interfaces;

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

    public void SaveAsJson(string taskJson, string destinationPath)
    {
        System.IO.File.WriteAllText(destinationPath, taskJson);
    }
}