using Model.Nodes;

namespace Model.Interfaces;

public interface ITerminal
{
    public string Value { get; }

    public string GetType()
    {
        var node = this as Node;
        return node.Name;
    }
}