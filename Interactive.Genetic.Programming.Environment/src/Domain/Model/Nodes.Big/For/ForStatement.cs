using System.Text;
using CommunityToolkit.Diagnostics;
using Configuration;
using Model.Abstract;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.FunctionCall;
using Model.Nodes.Big.If;
using Model.Nodes.Small;
using Model.Nodes.Small.Expressions.Logic;

namespace Model.Nodes.Big.For;

public sealed class ForStatement : DeepNode
{
    private readonly ForAssignment _forAssignment;
    public ComparisonExpression ComparisonExpression { get; set; }
    public ForIncrement ForIncrement { get; set; }

    public double NextComparisonExpressionChance { get; set; }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };

        nodes.AddRange(_forAssignment.ChildrenAsNodes());
        nodes.AddRange(ComparisonExpression.ChildrenAsNodes());
        nodes.AddRange(ForIncrement.ChildrenAsNodes());

        foreach (var node in ChildrenNodes)
        {
            nodes.AddRange(node.ChildrenAsNodes() ?? []);
        }

        return nodes;
    }

    public override List<Node> ChildrenAsNodesWithBlocks()
    {
        var nodes = new List<Node> { this };

        nodes.AddRange(_forAssignment.ChildrenAsNodes());
        nodes.AddRange(ComparisonExpression.ChildrenAsNodes());
        nodes.AddRange(ForIncrement.ChildrenAsNodes());

        nodes.Add(new BlockNode("Start ForStatement"));
        foreach (var node in ChildrenNodes)
        {
            nodes.AddRange(node.ChildrenAsNodesWithBlocks() ?? []);
        }

        nodes.Add(new BlockNode("End ForStatement"));

        return nodes;
    }

    public override string ToString()
    {
        var forBody = new StringBuilder();

        forBody.Append($"for ({_forAssignment}, {ComparisonExpression}, {ForIncrement}) {{\n");

        foreach (var node in ChildrenNodes)
        {
            forBody.Append('\t', Indent).Append(node).Append('\n');
        }

        forBody.Append('\t', Indent - 1).Append('}');

        return forBody.ToString();
    }

    public override void AddNodes(List<Token> tokens)
    {
        while (tokens.Count > 0)
        {
            var token = tokens[0];

            switch (token.Name)
            {
                case "Assignment":
                    AddNode(new Assignment(this, tokens));
                    break;
                case "FunctionCallOut":
                    AddNode(new FunctionCallOut(this, tokens));
                    break;
                case "IfStatement":
                    var ifStatement = new IfStatement(this, tokens);
                    AddNode(ifStatement);
                    ifStatement.AddNodes(tokens);
                    break;
                case "ForStatement":
                    var forStatement = new ForStatement(this, tokens);
                    AddNode(forStatement);
                    forStatement.AddNodes(tokens);
                    break;
                case "End ForStatement":
                    tokens.RemoveAt(0);
                    return;
                default:
                    throw new InvalidOperationException($"Unknown token: {tokens[0]}");
            }
        }
    }

    public ForStatement(Node parentNode)
        : base(parentNode, "ForStatement", false)
    {
        var configuration = ConfigurationResolver.Resolve<IForStatementConfiguration>();
        Guard.IsNotNull(configuration);

        NextChildChance = configuration.NewChildOfForNodeChance;
        NextDeepNodeChance = ParentNextDeepNodeChance * (1 - configuration.NewDeepNodeGenerationFall / 100);
        NextComparisonExpressionChance = configuration.NewExpressionInForComparisonChance;

        Indent = ParentIndent + 1;

        _forAssignment = new ForAssignment(this);
        ComparisonExpression = new ComparisonExpression(this, NextComparisonExpressionChance);
        ForIncrement = new ForIncrement(this);
    }

    public ForStatement(Node parentNode, List<Token> tokens)
        : base(parentNode, "ForStatement", false)
    {
        var configuration = ConfigurationResolver.Resolve<IForStatementConfiguration>();
        Guard.IsNotNull(configuration);
        tokens.RemoveAt(0);

        NextChildChance = configuration.NewChildOfForNodeChance;
        NextDeepNodeChance = ParentNextDeepNodeChance * (1 - configuration.NewDeepNodeGenerationFall / 100);
        NextComparisonExpressionChance = configuration.NewExpressionInForComparisonChance;

        Indent = ParentIndent + 1;

        _forAssignment = new ForAssignment(this, tokens);
        ComparisonExpression = new ComparisonExpression(this, tokens, NextComparisonExpressionChance);
        ForIncrement = new ForIncrement(this, tokens);

        tokens.RemoveAt(0);
    }
}