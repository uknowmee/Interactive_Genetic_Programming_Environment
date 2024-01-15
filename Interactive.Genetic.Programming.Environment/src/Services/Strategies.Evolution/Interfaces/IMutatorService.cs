using Model.Nodes.Big.Program.Root;

namespace Strategies.Evolution.Interfaces;

public interface IMutatorService
{
    void PointMutate(Program program);
    void SubtreeMutate(Program program);
}