namespace Shared.Interfaces;

public interface IEvaluable
{
    int ProgramLength { get; }
    int NumberOfVariables { get; }
    int NumberOfNodes { get; }
    List<ITestCase> TestCases { get; }
}