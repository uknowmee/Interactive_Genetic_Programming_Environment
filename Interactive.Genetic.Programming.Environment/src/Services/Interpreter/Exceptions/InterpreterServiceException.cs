namespace Interpreter.Exceptions;

public class InterpreterServiceException : Exception
{
    public InterpreterServiceException(string message) : base(message)
    {
    }
    
    public InterpreterServiceException(string message, Exception inner) : base(message, inner)
    {
    }
}