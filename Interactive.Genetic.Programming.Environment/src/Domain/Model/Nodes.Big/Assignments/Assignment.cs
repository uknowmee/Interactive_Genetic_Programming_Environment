using Model.Interfaces.Evolution;

namespace Model.Nodes.Big.Assignments;

public class Assignment : ISubtreeMutable
{
    public FunctionCallIn? Read { get; set; }
    public void SubtreeMutate()
    {
        throw new NotImplementedException();
    }
}