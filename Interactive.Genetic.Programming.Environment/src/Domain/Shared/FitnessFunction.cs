namespace Shared;

public class FitnessFunction
{
    public string Name { get; set; }
    
    public string Code { get; set; }
    
    public FitnessFunction(string fitnessFunctionName, string fitnessFunctionCode)
    {
        Name = fitnessFunctionName;
        Code = fitnessFunctionCode;
    }
}