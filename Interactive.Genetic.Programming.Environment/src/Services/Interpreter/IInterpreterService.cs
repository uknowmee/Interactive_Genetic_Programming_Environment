namespace Interpreter;

public interface IInterpreterService
{
    public bool IsFinished { get; }
    public List<double> Outputs { get; }
    public void Feed(string program);
    public void Run(List<double> inputs);
}