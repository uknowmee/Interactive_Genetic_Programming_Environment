using Microsoft.Extensions.Logging;
using Model.Abstract;
using Model.Extensions;
using Model.Interfaces;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Big.FunctionCall;
using Model.Nodes.Big.If;
using Model.Nodes.Big.Program.Root;
using Model.Nodes.Small.Expressions.Standard;
using Strategies.Evolution.Interfaces;
using Utils;

namespace Strategies.Evolution;

public class CrossingService : ICrossingService
{
    private readonly ILogger<CrossingService> _logger;
    private int _depth;
    private List<Node> _program1NodesWithBlocks = [];
    private List<Node> _program2NodesWithBlocks = [];

    public CrossingService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<CrossingService>();
    }

    public Program? Cross(Program parent1, Program parent2)
    {
        _logger.LogDebug("Crossing");
        Initialize(parent1, parent2);

        Program? program;
        try
        {
            program = EvalCrossing(0);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while crossing");
            return null;
        }

        _depth = 0;
        _program1NodesWithBlocks = [];
        _program2NodesWithBlocks = [];

        _logger.LogDebug("Crossing Finished successfully");
        return program;
    }

    private Program EvalCrossing(int depth)
    {
        while (true)
        {
            if (depth >= _depth) { throw new Exception("Depth exceeded, could not cross"); }

            var node1 = GetFirstCrossableNode();
            var node2 = GetSecondCrossableNode(node1);

            if (node2 is null)
            {
                depth += 1;
                continue;
            }

            var program = Swap(node1, node2);

            if (program != null) return program;
            depth += 1;
        }
    }

    private Node GetFirstCrossableNode()
    {
        var size1 = _program1NodesWithBlocks.Count;
        var node = _program1NodesWithBlocks[RandomService.RandomInt(size1)];

        var i = 0;
        while ((node is ICrossable or Assignment { Read: null }) is false)
        {
            if (i == _program1NodesWithBlocks.Count)
            {
                throw new Exception("Could not find first crossable node");
            }

            node = _program1NodesWithBlocks[RandomService.RandomInt(size1)];
            i += 1;
        }

        return node;
    }

    private Node? GetSecondCrossableNode(Node node1)
    {
        var compatibleWithFirst = new List<Node>(_program2NodesWithBlocks);
        var type = node1.GetType();
        
        switch (node1)
        {
            case Assignment { Read: null } or ForStatement or FunctionCallOut or IfStatement:
                compatibleWithFirst.RemoveAll(node
                    => !(node.GetType() == type || node is ForStatement || node is FunctionCallOut || node is IfStatement)
                );
            
                compatibleWithFirst.RemoveAll(node => node is Assignment { Read: not null });
                break;
            case AdditiveExpression or MultiplicativeExpression:
                compatibleWithFirst.RemoveAll(node => node is not (AdditiveExpression or MultiplicativeExpression));
                break;
            default:
                compatibleWithFirst.RemoveAll(node => node.GetType() != type);
                break;
        }
        
        return compatibleWithFirst.Count == 0 
            ? null 
            : compatibleWithFirst[RandomService.RandomInt(compatibleWithFirst.Count)];
    }

    private Program? Swap(Node node1, Node node2)
    {
        var sub1 = node1.ChildrenAsNodesWithBlocks() ?? [];
        var sub2 = node2.ChildrenAsNodesWithBlocks() ?? [];

        if (VariablesCheck(node1, sub2) is false)
        {
            return null;
        }
        
        var idxStart1 = GetNodeIdx(node1, _program1NodesWithBlocks);

        for (var i = 0; i < sub1.Count; i++)
        {
            _program1NodesWithBlocks.RemoveAt(idxStart1);
        }
        _program1NodesWithBlocks.InsertRange(idxStart1, sub2);

        return Program.FromTokens(_program1NodesWithBlocks.NodesWithBlocksAsTokens());
    }

    private static int GetNodeIdx(Node node1, IReadOnlyList<Node> program1NodesWithBlocks)
    {
        for (var i = 0; i < program1NodesWithBlocks.Count; i++)
        {
            if (program1NodesWithBlocks[i].GetHashCode() == node1.GetHashCode())
            {
                return i;
            }
        }

        throw new Exception("Could not find node index");
    }

    private static bool VariablesCheck(Node node1, List<Node> sub2)
    {
        var variables = node1.ProgramVariables;
        var varIndexes = variables.Select(v => v.Value.Split("_")[1]).ToList();

        foreach (var node in sub2)
        {
            if (node is VarExpression varExpression && varIndexes.Contains(varExpression.Value.Split("_")[1]))
            {
                return false;
            }
        }

        return true;
    }

    private void Initialize(Program parent1, Program parent2)
    {
        _depth = 30;
        _program1NodesWithBlocks = parent1.ChildrenAsNodesWithBlocks();
        _program2NodesWithBlocks = parent2.ChildrenAsNodesWithBlocks();
    }
}