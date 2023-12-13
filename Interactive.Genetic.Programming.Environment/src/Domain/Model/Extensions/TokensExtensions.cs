using Model.Interfaces;
using Model.Nodes;

namespace Model.Extensions;

public static class TokensExtensions
{
    public static List<Token> NodesWithBlocksAsTokens(this List<Node> nodes)
    {
        var tokens = new List<Token>();
        
        foreach (var node in nodes)
        {
            if (node is ITerminal terminal)
            {
                tokens.Add(new Token(terminal.Type(), terminal.Value));
            }
            else
            {
                tokens.Add(new Token(node.Name, null));
            }
        }
        
        return tokens;
    }
}