using System.Data;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Interpreter.Exceptions;

namespace Interpreter;

public class InterpreterService : IInterpreterService
{
    public bool IsFinished { get; private set; } = false;
    public IEnumerable<double> Outputs => _visitor?.Outputs ?? [];

    private Visitor? _visitor = null;
    private readonly IParseTree _parseTree;

    private const int DueTime = 10;
    private CancellationTokenSource? _cancellationTokenSource;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    public void Run(List<double> inputs)
    {
        IsFinished = false;
        _visitor = new Visitor(inputs);

        try
        {
            _cancellationTokenSource = new CancellationTokenSource(DueTime);
            _semaphore.Wait(_cancellationTokenSource.Token);

            Task.Run(() =>
                {
                    _visitor?.Visit(_parseTree);
                    IsFinished = true;
                }, _cancellationTokenSource.Token
            ).Wait(_cancellationTokenSource.Token);
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