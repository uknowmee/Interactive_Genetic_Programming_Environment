using System.Text;
using CommunityToolkit.Diagnostics;
using Configuration;
using Model.Abstract;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Big.FunctionCall;
using Model.Nodes.Small;
using Model.Nodes.Small.Expressions.Logic;

namespace Model.Nodes.Big.If;

public sealed class IfStatement : DeepNode
{
    public LogicExpression LogicExpression { get; set; }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };
        nodes.AddRange(LogicExpression.ChildrenAsNodes());

        foreach (var node in ChildrenNodes)
        {
            nodes.AddRange(node.ChildrenAsNodes() ?? []);
        }

        return nodes;
    }

    public override List<Node> ChildrenAsNodesWithBlocks()
    {
        var nodes = new List<Node> { this };
        nodes.AddRange(LogicExpression.ChildrenAsNodes());

        nodes.Add(new BlockNode("Start IfStatement"));
        foreach (var node in ChildrenNodes)
        {
            nodes.AddRange(node.ChildrenAsNodesWithBlocks() ?? []);
        }

        nodes.Add(new BlockNode("End IfStatement"));

        return nodes;
    }

    public override string ToString()
    {
        var ifBody = new StringBuilder();

        ifBody.Append($"if ({LogicExpression}) {{{Environment.NewLine}");

        foreach (var node in ChildrenNodes)
        {
            ifBody.Append(new string('\t', Indent)).Append(node).Append(Environment.NewLine);
        }

        ifBody.Append(new string('\t', Indent - 1)).Append('}');

        return ifBody.ToString();
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
                case "End IfStatement":
                    tokens.RemoveAt(0);
                    return;
                default:
                    throw new InvalidOperationException($"unknown token: {tokens[0]}");
            }
        }
    }

    public IfStatement(Node parentNode)
        : base(parentNode, "IfStatement", false)
    {
        var configuration = ConfigurationResolver.Resolve<IIfStatementConfiguration>();
        Guard.IsNotNull(configuration);

        NextChildChance = configuration.NewChildOfIfNodeChance;
        NextDeepNodeChance = ParentNextDeepNodeChance * (1 - configuration.NewDeepNodeGenerationFall / 100);

        Indent = ParentIndent + 1;

        LogicExpression = new LogicExpression(this);
    }

    public IfStatement(Node parentNode, List<Token> tokens)
        : base(parentNode, "IfStatement", false)
    {
        var configuration = ConfigurationResolver.Resolve<IIfStatementConfiguration>();
        Guard.IsNotNull(configuration);
        tokens.RemoveAt(0);

        NextChildChance = configuration.NewChildOfIfNodeChance;
        NextDeepNodeChance = ParentNextDeepNodeChance * (1 - configuration.NewDeepNodeGenerationFall / 100);

        Indent = ParentIndent + 1;

        LogicExpression = new LogicExpression(this, tokens);
        
        tokens.RemoveAt(0);
    }
}