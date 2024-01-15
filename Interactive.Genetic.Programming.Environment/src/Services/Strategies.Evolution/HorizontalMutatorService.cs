using Microsoft.Extensions.Logging;
using Model.Abstract;
using Model.Nodes.Big.Program.Root;
using Strategies.Evolution.Interfaces;
using Utils;

namespace Strategies.Evolution;

public class HorizontalMutatorService : IHorizontalMutatorService
{
    private List<Node> _nodes = [];
    private readonly List<BigNode> _growingNodes = [];
    private readonly ILogger<HorizontalMutatorService> _logger;
    
    public HorizontalMutatorService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<HorizontalMutatorService>();
    }
    
    public void GrowOnceInsideBlock(Program program)
    {
        _logger.LogDebug("Growing once inside block");
        Initialize(program);
        _growingNodes[RandomService.RandomInt(_growingNodes.Count)].AddBigNode();
        _logger.LogDebug("Growing once inside block finished successfully");
    }

    public void SwapTwoLines(Program program)
    {
        _logger.LogDebug("Swapping two lines");
        Initialize(program);
        
        var node = _growingNodes[RandomService.RandomInt(_growingNodes.Count)];

        if (_growingNodes.Count == 1 && node is Program pr && pr.ChildrenNodes.Count <= pr.Inputs + 1)
        {
            _logger.LogDebug("Swapping two lines finished successfully - no swap possible");
            return;
        }

        while (node.ChildrenNodes.Count <= 1)
        {
            node = _growingNodes[RandomService.RandomInt(_growingNodes.Count)];
        }
        
        if (node is Program pr1 && pr1.ChildrenNodes.Count <= pr1.Inputs + 1)
        {
            _logger.LogDebug("Swapping two lines finished successfully - no swap possible");
            return;
        }
        
        node.SwapTwoLines();
        _logger.LogDebug("Swapping two lines finished successfully");
    }

    public void DeleteLine(Program program)
    {
        _logger.LogDebug("Deleting line");
        Initialize(program);
        
        var node = _growingNodes[RandomService.RandomInt(_growingNodes.Count)];
        
        if (_growingNodes.Count == 1 && node is Program pr && pr.ChildrenNodes.Count <= pr.Inputs + 1)
        {
            _logger.LogDebug("Deleting line finished successfully - no deletion possible");
            return;
        }
        
        while (node.ChildrenNodes.Count < 1)
        {
            node = _growingNodes[RandomService.RandomInt(_growingNodes.Count)];
        }
        
        if (node is Program pr1 && pr1.ChildrenNodes.Count <= pr1.Inputs + 1)
        {
            _logger.LogDebug("Deleting line finished successfully - no deletion possible");
            return;
        }
        
        node.DeleteRandomLine();
        _logger.LogDebug("Deleting line finished successfully");
    }

    private void Initialize(Program program)
    {
        _nodes = program.ChildrenAsNodes();
        _growingNodes.Clear();
        
        _growingNodes.Add(program);
        foreach (var node in _nodes)
        {
            if (node is BigNode bigNode)
            {
                _growingNodes.Add(bigNode);
            }
        }
    }
}