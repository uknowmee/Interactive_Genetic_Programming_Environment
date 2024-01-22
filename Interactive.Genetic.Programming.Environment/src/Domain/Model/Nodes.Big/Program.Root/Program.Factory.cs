using CommunityToolkit.Diagnostics;
using Configuration;
using Configuration.Model;
using Model.Extensions;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Big.FunctionCall;
using Model.Nodes.Big.If;

namespace Model.Nodes.Big.Program.Root;

public partial class Program
{
    public Program(int numOfInputs)
        : base(null, "Program", false)
    {
        var config = ConfigurationResolver.Resolve<IProgramConfiguration>();
        Guard.IsNotNull(config);

        NextChildChance = config.NewChildOfProgramNodeChance;
        NextDeepNodeChance = config.NewDeepNodeGenerationChance;
        Inputs = numOfInputs;

        for (var i = 0; i < Inputs; i++)
        {
            AddNode(new Assignment(this, false));
        }

        AddBigNode();
    }

    public static Program FromTokens(List<Token> tokens) => new(tokens);

    public Program Copy() => new(ChildrenAsNodesWithBlocks().NodesWithBlocksAsTokens());

    private Program(List<Token> tokens)
        : base(null, "Program", false)
    {
        var config = ConfigurationResolver.Resolve<IProgramConfiguration>();
        Guard.IsNotNull(config);

        NextChildChance = config.NewChildOfProgramNodeChance;
        NextDeepNodeChance = config.NewDeepNodeGenerationChance;

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
                default:
                    throw new InvalidOperationException($"Unknown token: {tokens[0]}");
            }

            Inputs += ChildrenNodes?
                .TakeWhile(node => node is not Assignment { Read: null })
                .Count() ?? 0;
        }
    }
}