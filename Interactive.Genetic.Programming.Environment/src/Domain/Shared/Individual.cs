using Shared.Interfaces;

namespace Shared;

public class Individual : IEvaluable
{
    public double FitnessValue { get; set; } = 0.0;

    public string ProgramString => "Mock program";
    public int ProgramLength => 3;
    public int NumberOfVariables => 2;
    public int NumberOfNodes => 1;
    
    public Task Task { get; set; } = new()
    {
        InputLength = 2,
        TaskName = "Mock task",
        TestCases =
        [
            new TestCase
            {
                Input = new Vector { Values = [1, 2] },
                Output = new Vector { Values = [3] },
                ProgramOutput = new Vector { Values = [3] }
            },

            new TestCase
            {
                Input = new Vector { Values = [2, 3] },
                Output = new Vector { Values = [5] },
                ProgramOutput = new Vector { Values = [6] }
            }
        ]
    };

    public List<ITestCase> TestCases => [..Task.TestCases];
}