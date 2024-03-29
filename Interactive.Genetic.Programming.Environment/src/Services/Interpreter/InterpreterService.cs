﻿using System.Data;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Configuration.Solver;
using Interpreter.Exceptions;

namespace Interpreter;

public class InterpreterService : IInterpreterService
{
    public bool IsFinished { get; private set; }
    public List<double> Outputs => _visitor?.Outputs ?? [];

    private Visitor? _visitor;
    private IParseTree? _parseTree;

    private readonly int _dueTime;

    public void Run(List<double> inputs)
    {
        Run(inputs, _dueTime);
    }

    public void Run(List<double> inputs, int executionTime)
    {
        IsFinished = false;

        try
        {
            _visitor = new Visitor(inputs, executionTime);
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

    public void Feed(string program)
    {
        IsFinished = false;
        _visitor = null;
        _parseTree = null;
        
        var lexer = new IntGrammarLexer(new AntlrInputStream(program));
        var parser = new IntGrammarParser(new CommonTokenStream(lexer));
        _parseTree = parser.program();

        if (parser.NumberOfSyntaxErrors > 0)
        {
            throw new SyntaxErrorException("Syntax error in program.");
        }
    }
    
    public InterpreterService(ISolverConfiguration solverConfiguration)
    {
        _dueTime = solverConfiguration.ExecutionTime;
    }
}