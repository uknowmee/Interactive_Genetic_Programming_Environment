using System.Text.Json.Serialization;
using Shared.Interfaces;

namespace Shared;

public class TestCase : ITestCase
{
    [JsonPropertyName("input")] public Vector Input { get; set; } = new();
    [JsonPropertyName("output")] public Vector Output { get; set; } = new();
    [JsonPropertyName("programOutput")] public Vector ProgramOutput { get; set; } = new();

    [JsonIgnore] List<double> ITestCase.Input => Input.Values;
    [JsonIgnore] List<double> ITestCase.Output => Output.Values;
    [JsonIgnore] List<double> ITestCase.Predicted => ProgramOutput.Values;

    public TestCase Copy()
    {
        return new TestCase
        {
            Input = Input.Copy(),
            Output = Output.Copy(),
            ProgramOutput = ProgramOutput.Copy()
        };
    }
}