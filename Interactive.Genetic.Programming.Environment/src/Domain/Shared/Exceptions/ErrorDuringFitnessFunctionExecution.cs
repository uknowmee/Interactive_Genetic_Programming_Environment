namespace Shared.Exceptions;

public class ErrorDuringFitnessFunctionExecution : Exception
{
    public ErrorDuringFitnessFunctionExecution() : base()
    {
        
    }
    
    public ErrorDuringFitnessFunctionExecution(string message) : base(message)
    {
        
    }
    
    public ErrorDuringFitnessFunctionExecution(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}