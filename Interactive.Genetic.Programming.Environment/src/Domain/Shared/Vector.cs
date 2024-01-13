using System.Text.Json.Serialization;

namespace Shared;

public class Vector
{
    [JsonPropertyName("values")] public List<double> Values { get; set; }
}