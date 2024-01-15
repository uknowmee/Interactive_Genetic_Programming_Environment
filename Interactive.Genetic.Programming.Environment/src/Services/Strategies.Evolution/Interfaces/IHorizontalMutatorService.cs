using Model.Nodes.Big.Program.Root;

namespace Strategies.Evolution.Interfaces;

public interface IHorizontalMutatorService
{
    void GrowOnceInsideBlock(Program program);
    void DeleteLine(Program program);
    void SwapTwoLines(Program program);
}