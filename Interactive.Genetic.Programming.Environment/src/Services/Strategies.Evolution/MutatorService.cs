using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Model.Interfaces;
using Model.Nodes.Big.Program.Root;
using Strategies.Evolution.Interfaces;
using Utils;

namespace Strategies.Evolution;

public class MutatorService : IMutatorService
{
    private readonly ILogger<MutatorService> _logger;
    
    public MutatorService(ILoggerFactory? loggerFactory = null)
    {
        _logger = loggerFactory?.CreateLogger<MutatorService>() ?? NullLogger<MutatorService>.Instance;
    }
    
    public void PointMutate(Program program)
    {
        _logger.LogDebug("Point mutating");
        var pointMutable = GetPointMutableNodes(program);
        
        if (pointMutable.Count == 0)
        {
            _logger.LogDebug("Point mutating finished successfully - no point mutable nodes");
            return;
        }
        
        pointMutable[RandomService.RandomInt(pointMutable.Count)].Mutate();
        
        program.UpdateVariables();
        _logger.LogDebug("Point mutating finished successfully");
    }

    public void SubtreeMutate(Program program)
    {
        _logger.LogDebug("Subtree mutating");
        var subtreeMutable = GetSubtreeMutableNodes(program);
        
        if (subtreeMutable.Count == 0)
        {
            _logger.LogDebug("Subtree mutating finished successfully - no subtree mutable nodes");
            return;
        }
        
        subtreeMutable[RandomService.RandomInt(subtreeMutable.Count)].SubtreeMutate();
        
        program.UpdateVariables();
        _logger.LogDebug("Subtree mutating finished successfully");
    }
    
    private static List<IPointMutable> GetPointMutableNodes(Program program)
    {
        return program.ChildrenAsNodes()
            .OfType<IPointMutable>()
            .Where(node => node.IsMutable())
            .ToList();
    }
    
    private static List<ISubtreeMutable> GetSubtreeMutableNodes(Program program)
    {
        return program.ChildrenAsNodes()
            .OfType<ISubtreeMutable>()
            .Where(node => node.IsMutable())
            .ToList();
    }
}