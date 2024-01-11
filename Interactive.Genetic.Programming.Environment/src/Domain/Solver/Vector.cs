using System.Text.Json.Serialization;

namespace Solver;

public class Vector
{
    [JsonPropertyName("values")] public List<double> Values { get; set; }
}