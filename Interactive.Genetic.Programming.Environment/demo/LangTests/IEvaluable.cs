using System.Collections.Generic;

namespace LangTests;

public interface IEvaluable
{
    int ProgramLength { get; }
    int NumberOfVariables { get; }
    int NumberOfNodes { get; }
    List<ITestCase> TestCases { get; }
}

public interface ITestCase
{
    public List<double> Input { get; }
    public List<double> Output { get; }
    public List<double> Predicted { get; }
}

public class Evaluable : IEvaluable
{
    public int ProgramLength { get; set; } = 3;
    public int NumberOfVariables { get; set; } = 2;
    public int NumberOfNodes { get; set; } = 1;

    public List<ITestCase> TestCases { get; set; } =
    [
        new TestCase
        {
            Input = [1, 2],
            Output = [3],
            Predicted = [3]
        },
        new TestCase
        {
            Input = [2, 3],
            Output = [5],
            Predicted = [6]
        }
    ];
}

public class TestCase : ITestCase
{
    public List<double> Input { get; set; } = [];
    public List<double> Output { get; set; } = [];
    public List<double> Predicted { get; set; } = [];
}