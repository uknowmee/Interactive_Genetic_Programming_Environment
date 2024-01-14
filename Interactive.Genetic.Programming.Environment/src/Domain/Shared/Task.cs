using System.Text.Json;
using System.Text.Json.Serialization;
using Shared.Interfaces;

namespace Shared;

public class Task : IPrettySerializable
{
    [JsonPropertyName("taskName")] public string TaskName { get; set; }
    [JsonPropertyName("inputLength")] public int InputLength { get; set; }
    [JsonPropertyName("testCases")] public List<TestCase> TestCases { get; set; }

    [JsonIgnore] string IPrettySerializable.JsonToFile => JsonSerializer.Serialize(this, JsonSerializerOptions);
    [JsonIgnore] public string Json => JsonSerializer.Serialize(this, JsonSerializerOptions);

    [JsonIgnore] private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true
    };
}