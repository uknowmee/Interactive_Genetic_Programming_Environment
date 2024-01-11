namespace File.Interfaces;

public interface IFileService
{
    public object? ReadFromJson<T>(string path);
    void SaveAsJson(string taskJson, string destinationPath);
}