namespace Interpreter.Exceptions;

public class ExecutionTimeExceededException : Exception
{
    public ExecutionTimeExceededException(string message) : base(message)
    {
    }
    
    public ExecutionTimeExceededException(string message, Exception inner) : base(message, inner)
    {
    }
}