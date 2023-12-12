using Model.Nodes.Big.Assignment;

namespace Model.Interfaces.Evolution;

public interface ISubtreeMutable
{
    public void SubtreeMutate();

    public bool IsMutable() => this is not Assignment assignment || assignment.Read is null;
}