using System.Text.Json.Serialization;

namespace Solver;

public class TestCase
{
    [JsonPropertyName("input")] public Vector Input { get; set; }
    [JsonPropertyName("output")] public Vector Output { get; set; }
    [JsonPropertyName("programOutput")] public Vector ProgramOutput { get; set; }

    [JsonIgnore] public List<double> Inputs => Input.Values;
    [JsonIgnore] public List<double> Outputs => Output.Values;
    [JsonIgnore] public List<double> ProgramOutputs => ProgramOutput.Values;
}