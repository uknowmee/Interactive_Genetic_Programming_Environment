﻿using CommunityToolkit.Diagnostics;
using Configuration;
using Configuration.Model;
using Model.Abstract;
using Model.Nodes.Small.Constants;

namespace Model.Nodes.Small.Expressions.Standard;

public partial class StandardExpression
{
    private void SetExpression(List<Token> tokens)
    {
        switch (tokens[0].Name)
        {
            case "Constant":
                _constant = new Constant(this, tokens);
                break;
            case "VarExpression":
                _varExpression = new VarExpression(this, tokens);
                break;
            case "MultiplicativeExpression":
                _multiplicativeExpression = new MultiplicativeExpression(this, tokens);
                break;
            case "AdditiveExpression":
                _additiveExpression = new AdditiveExpression(this, tokens);
                break;
            default:
                throw new InvalidOperationException($"Unknown token: {tokens[0]}");
        }
    }
    
    public StandardExpression(Node parentNode) 
        : base(parentNode, "Expression", true)
    {
        var configuration = ConfigurationResolver.Resolve<IStandardExpressionConfiguration>();
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
    
    public StandardExpression(Node parentNode, List<Token> tokens) 
        : base(parentNode, "Expression", true)
    {
        var configuration = ConfigurationResolver.Resolve<IStandardExpressionConfiguration>();
        Guard.IsNotNull(configuration);
        
        NextTwoArgExpressionChance = configuration.NextTwoArgExpressionChance;
        tokens.RemoveAt(0);
        SetExpression(tokens);
    }
    
    public StandardExpression(Node parentNode, List<Token> tokens, double lastNextTwoArgExpressionChance) 
        : base(parentNode, "Expression", true)
    {
        NextTwoArgExpressionChance = lastNextTwoArgExpressionChance;
        tokens.RemoveAt(0);
        SetExpression(tokens);
    }
}