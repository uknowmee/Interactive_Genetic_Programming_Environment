using Model.Nodes;

namespace Model.Interfaces;

public interface ITerminal
{
    public string Value { get; }

    public string Type()
    {
        var node = this as Node;
        return node.Name;
    }
}