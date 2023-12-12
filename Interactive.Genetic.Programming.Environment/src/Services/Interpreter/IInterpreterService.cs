namespace Interpreter;

public interface IInterpreterService
{
    public bool IsFinished { get; }
    public IEnumerable<double> Outputs { get; }
    public void Run(List<double> inputs);
}