namespace Shared.Interfaces;

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