using Model.Nodes.Big.Program.Root;

namespace Strategies.Evolution.Interfaces;

public interface ICrossingService
{
    Program? Cross(Program parent1, Program parent2);
}