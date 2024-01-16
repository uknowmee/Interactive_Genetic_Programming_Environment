using Shared.Interfaces;

namespace File.Interfaces;

public interface IFileService
{
    public object? ReadFromJson<T>(string path);
    public object? ReadFromCsv<T>(string path) where T : ICsvSerializable;
    void SaveAsJson<T>(string json, string destinationPath) where T : IPrettySerializable;
    void SaveAsJson<T>(T serializable, string destinationPath) where T : IPrettySerializable;
    public void SaveAsCsv<T>(string json, string destinationPath) where T : IPrettySerializable, ICsvSerializable;
    public void SaveAsCsv<T>(T csvSerializable, string destinationPath) where T : ICsvSerializable;
    void DeleteAt(string path);
    bool DoesFileExist(string path);
}