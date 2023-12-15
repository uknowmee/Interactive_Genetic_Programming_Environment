using Model.Extensions;
using Model.Interfaces;
using Model.Interfaces.Evolution;

namespace Model.Nodes.Small;

public abstract class Operator : Node, IPointMutable, ITerminal
{
    public string Value { get; set; } = string.Empty;

    public string OperatorValue => Value.Replace(" ", "");

    public override List<Node> ChildrenAsNodes() => [this];

    public abstract void Mutate();

    protected Operator(Node parentNode, string name) : base(parentNode, name, true)
    {
    }

    protected Operator(Node parentNode, IList<Token> tokens) : base(parentNode, tokens[0].Name, true)
        => Value = tokens.PopFront().Value ?? throw new NullReferenceException();

    public override string ToString() => Value;
}