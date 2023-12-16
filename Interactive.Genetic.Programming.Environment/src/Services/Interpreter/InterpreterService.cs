using System.Data;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Interpreter.Exceptions;

namespace Interpreter;

public class InterpreterService : IInterpreterService
{
    public bool IsFinished { get; private set; }
    public IEnumerable<double> Outputs => _visitor?.Outputs ?? [];

    private Visitor? _visitor;
    private readonly IParseTree _parseTree;

    private const int DueTime = 10;

    public void Run(List<double> inputs)
    {
        IsFinished = false;

        try
        {
            _visitor = new Visitor(inputs, DueTime);
            _visitor.Visit(_parseTree);
            IsFinished = true;
        }
        catch (OperationCanceledException exception)
        {
            throw new ExecutionTimeExceededException("Time limit for interpreting the program has exceeded.", exception);
        }
        catch (Exception exception)
        {
            throw new InterpreterServiceException("An error occurred while interpreting the program.", exception);
        }
    }

    public InterpreterService(string program)
    {
        var lexer = new IntGrammarLexer(new AntlrInputStream(program));
        var parser = new IntGrammarParser(new CommonTokenStream(lexer));
        _parseTree = parser.program();

        if (parser.NumberOfSyntaxErrors > 0)
        {
            throw new SyntaxErrorException("Syntax error in program.");
        }
    }
}