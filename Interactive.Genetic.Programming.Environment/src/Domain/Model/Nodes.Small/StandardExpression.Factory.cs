using CommunityToolkit.Diagnostics;
using Configuration;
using Model.Nodes.Small.Constants;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes.Small;

public partial class StandardExpression
{
    public StandardExpression(Node parentNode, IStandardExpressionConfiguration? configuration = null) 
        : base(parentNode, "Expression", true)
    {
        Guard.IsNotNull(configuration);
        
        NextTwoArgExpressionChance = configuration.NextTwoArgExpressionChance;
        AddStandardExpression();
    }
    
    public StandardExpression(Node parentNode, double lastNextTwoArgExpressionChance) 
        : base(parentNode, "Expression", true)
    {
        NextTwoArgExpressionChance = lastNextTwoArgExpressionChance;
        AddStandardExpression();
    }
    
    public StandardExpression(Node parentNode, List<Token> tokens,IStandardExpressionConfiguration? configuration = null) 
        : base(parentNode, "Expression", true)
    {
        Guard.IsNotNull(configuration);
        
        NextTwoArgExpressionChance = configuration.NextTwoArgExpressionChance;
        tokens.RemoveAt(0);
        
        tokens[0].Name switch
        {
            "Constant" => _constant = new Constant(this, tokens),
            "VarExpression" => _varExpression = new VarExpression(this, tokens),
            "MultiplicativeExpression" => _multiplicativeExpression = new MultiplicativeExpression(this, tokens),
            "AdditiveExpression" => _additiveExpression = new AdditiveExpression(this, tokens),
            _ => throw new ArgumentException("Invalid token name")
        };
    }
    
    public StandardExpression(Node parentNode, List<Token> tokens, double lastNextTwoArgExpressionChance) 
        : base(parentNode, "Expression", true)
    {
        NextTwoArgExpressionChance = lastNextTwoArgExpressionChance;
        tokens.RemoveAt(0);
        
        tokens[0].Name switch
        {
            "Constant" => _constant = new Constant(this, tokens),
            "VarExpression" => _varExpression = new VarExpression(this, tokens),
            "MultiplicativeExpression" => _multiplicativeExpression = new MultiplicativeExpression(this, tokens),
            "AdditiveExpression" => _additiveExpression = new AdditiveExpression(this, tokens),
            _ => throw new ArgumentException("Invalid token name")
        };
    }
}