using Shared;
using Shared.Interfaces;

namespace File.Interfaces;

public interface IFileService
{
    public object? ReadFromJson<T>(string path);
    public object? ReadFromCsv<T>(string path);
    void SaveAsJson<T>(string json, string destinationPath) where T : IPrettySerializable;
    void SaveAsJson<T>(T serializable, string destinationPath) where T : IPrettySerializable;
    void DeleteAt(string path);
    bool DoesFileExist(string path);
}