using CommunityToolkit.Diagnostics;
using Configuration;
using Configuration.Model;
using Model.Abstract;
using Model.Extensions;
using Model.Interfaces;
using Model.Nodes.Big.For;
using Model.Nodes.Big.FunctionCall;
using Utils;

namespace Model.Nodes.Small.Expressions.Standard;

public sealed class VarExpression : Node, IPointMutable, ITerminal
{
    public string Value { get; set; }

    public void Mutate()
    {
        var oldVariable = Value;

        if (ParentNode is ForIncrement or FunctionCallOut)
        {
            for (var breaker = 0; breaker <= 100 && oldVariable == Value; breaker++)
            {
                Value = MakeAlreadyExisting();
            }
        }
        else if (ParentNode is StandardExpression expression)
        {
            expression.MutateConstOrVar();
        }
    }

    public override List<Node> ChildrenAsNodes() => [this];

    private string MakeAlreadyExisting()
    {
        var variables = ProgramVariables;

        if (variables.Count == 0) throw new InvalidOperationException("No variables to choose from");

        return variables[RandomService.RandomInt(variables.Count)].Value;
    }

    private string MakeNotAlreadyExisting()
    {
        var idx = 0;
        var indexes = ProgramVariables.GetIndexes();

        while (indexes.Contains(idx))
        {
            idx += 1;
        }

        return "x_" + idx;
    }

    private string MakeNew()
    {
        var configuration = ConfigurationResolver.Resolve<IVariablesConfiguration>();
        Guard.IsNotNull(configuration);
        var variables = ProgramVariables;

        if (variables.Count == 0) return "x_0";

        return RandomService.RandomPercentage() < configuration.NewVarExpressionChance
            ? MakeNotAlreadyExisting()
            : variables[RandomService.RandomInt(variables.Count)].Value;
    }

    public VarExpression(Node parentNode) : base(parentNode, "VarExpression", true)
    {
        Value = MakeNew();
        AddToProgramVariables(this);
    }

    public VarExpression(Node parentNode, bool shouldAlreadyExist) : base(parentNode, "VarExpression", true)
    {
        Value = shouldAlreadyExist ? MakeAlreadyExisting() : MakeNotAlreadyExisting();

        if (shouldAlreadyExist is false)
        {
            AddToProgramVariables(this);
        }
    }

    public VarExpression(Node parentNode, IList<Token> tokens) : base(parentNode, "VarExpression", true)
    {
        Value = tokens.PopFront().Value ?? throw new InvalidOperationException("Token value is null");
        AddToProgramVariables(this);
    }

    public VarExpression(Node parentNode, bool shouldAlreadyExist, IList<Token> tokens) : base(parentNode, "VarExpression", true)
    {
        Value = tokens.PopFront().Value ?? throw new InvalidOperationException("Token value is null");

        if (shouldAlreadyExist is false)
        {
            AddToProgramVariables(this);
        }
    }

    public override string ToString() => Value;
}