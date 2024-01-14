namespace Shared.Interfaces;

public interface ITestCase
{
    public List<double> Input { get; }
    public List<double> Output { get; }
    public List<double> Predicted { get; }
}