using CommunityToolkit.Diagnostics;
using Configuration;
using Configuration.Model;
using Model.Abstract;

namespace Model.Nodes.Small.Expressions.Logic;

public partial class LogicExpression
{
    private void SetExpression(List<Token> tokens)
    {
        switch (tokens[0].Name)
        {
            case "ComparisonExpression":
                _comparisonExpression = new ComparisonExpression(this, tokens);
                break;
            case "BooleanExpression":
                _booleanExpression = new BooleanExpression(this, tokens);
                break;
            default:
                throw new InvalidOperationException($"Unknown token: {tokens[0]}");
        }
    }

    public LogicExpression(Node parentNode)
        : base(parentNode, "LogicExpression", true)
    {
        var configuration = ConfigurationResolver.Resolve<ILogicExpressionConfiguration>();
        Guard.IsNotNull(configuration);

        NextLogicBooleanExpressionChance = configuration.NewLogicExpressionChance;
        AddLogicExpression();
    }

    public LogicExpression(Node parentNode, double lastNextLogicExpressionChance)
        : base(parentNode, "LogicExpression", true)
    {
        NextLogicBooleanExpressionChance = lastNextLogicExpressionChance;
        AddLogicExpression();
    }

    public LogicExpression(Node parentNode, List<Token> tokens)
        : base(parentNode, "LogicExpression", true)
    {
        var configuration = ConfigurationResolver.Resolve<ILogicExpressionConfiguration>();
        Guard.IsNotNull(configuration);

        NextLogicBooleanExpressionChance = configuration.NewLogicExpressionChance;
        tokens.RemoveAt(0);
        SetExpression(tokens);
    }

    public LogicExpression(Node parentNode, List<Token> tokens, double lastNextLogicExpressionChance)
        : base(parentNode, "LogicExpression", true)
    {
        NextLogicBooleanExpressionChance = lastNextLogicExpressionChance;
        tokens.RemoveAt(0);
        SetExpression(tokens);
    }
}