using System.Text.Json;
using File.Interfaces;
using Microsoft.Extensions.Logging;
using Serialization.Interfaces;
using Shared.Interfaces;

namespace File;

public class FileService : IFileService
{
    private readonly ILogger<FileService> _logger;
    private readonly ISerializationService _serializationService;
    
    public FileService(ILoggerFactory loggerFactory, ISerializationService serializationService)
    {
        _logger = loggerFactory.CreateLogger<FileService>();
        _serializationService = serializationService;
    }
    
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
            _logger.LogError(e, "Failed to read from JSON file");
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

    public object? ReadFromCsv<T>(string path) where T : ICsvSerializable
    {
        try
        {
            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException($"File not found: {path}");
            }

            var csvContent = System.IO.File.ReadAllText(path);

            return _serializationService.DeserializeTo<T>(csvContent);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to read from CSV file");
            return null;
        }
    }
    
    public void SaveAsCsv<T>(string json, string destinationPath) where T : IPrettySerializable, ICsvSerializable
    {
        var obj = JsonSerializer.Deserialize<T>(json) ?? throw new Exception("Failed to deserialize JSON content");
        SaveAsCsv(obj, destinationPath);
    }
    
    public void SaveAsCsv<T>(T csvSerializable, string destinationPath) where T : ICsvSerializable
    {
        var dirPath = Path.GetDirectoryName(destinationPath) ?? throw new Exception("Directory path is null");
        
        if (Directory.Exists(dirPath) is false)
        {
            Directory.CreateDirectory(dirPath);
        }
        
        var toSave = _serializationService.Serialize(csvSerializable) ?? throw new Exception("Failed to serialize CSV content");
        System.IO.File.WriteAllText(destinationPath, toSave);
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