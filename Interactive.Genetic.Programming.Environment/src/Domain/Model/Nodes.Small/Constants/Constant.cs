﻿using CommunityToolkit.Diagnostics;
using Configuration;
using Configuration.Model;
using Model.Abstract;
using Model.Extensions;
using Model.Interfaces;
using Model.Nodes.Big.For;
using Model.Nodes.Small.Expressions.Standard;
using Utils;

namespace Model.Nodes.Small.Constants;

public sealed class Constant : Node, IConstant, IPointMutable, ITerminal
{
    private readonly int _maxInt;
    private string _type;
    private string _value;

    public string Value => $"{_type} {_value}";

    public override List<Node> ChildrenAsNodes() => [this];

    public void AddConstant(ConstantType constantType)
    {
        _type = constantType.ToString();
        _value = RandomInteger();
    }

    public void Mutate()
    {
        if (ParentNode is ForIncrement)
        {
            var oldValue = _value;
            _value = RandomInteger();

            while (oldValue == _value)
            {
                _value = RandomInteger();
            }
        }
        else if (ParentNode is StandardExpression expression)
        {
            expression.MutateConstOrVar();
        }
    }

    private string RandomInteger() => RandomService.RandomInt(_maxInt).ToString();

    public Constant(Node parentNode) 
        : base(parentNode, "Constant", true)
    {
        var configuration = ConfigurationResolver.Resolve<IConstantConfiguration>();
        Guard.IsNotNull(configuration);
        _maxInt = configuration.MaxInt;
        
        var constantType = EnumExtensions.GetRandomValue<ConstantType>();
        _type = constantType.ToString();
        _value = RandomInteger();    }

    public Constant(Node parentNode, ConstantType givenConstant)
        : base(parentNode, "Constant", true)
    {
        var configuration = ConfigurationResolver.Resolve<IConstantConfiguration>();
        Guard.IsNotNull(configuration);
        
        _maxInt = configuration.MaxInt;
        _type = givenConstant.ToString();
        _value = RandomInteger();    }

    public Constant(Node parentNode, IList<Token> tokens)
        : base(parentNode, "Constant", true)
    {
        var configuration = ConfigurationResolver.Resolve<IConstantConfiguration>();
        Guard.IsNotNull(configuration);
        _maxInt = configuration.MaxInt;

        var token = tokens.PopFront();
        var data = token.Value?.Split(" ") ?? throw new NullReferenceException("Token value is null");
        
        _type = data[0];
        _value = data[1];
    }

    public Constant(Node parentNode, ConstantType givenConstant, IList<Token> tokens)
        : base(parentNode, "Constant", true)
    {
        var configuration = ConfigurationResolver.Resolve<IConstantConfiguration>();
        Guard.IsNotNull(configuration);
        _maxInt = configuration.MaxInt;

        var data = tokens.PopFront().Value?.Split(" ") ?? throw new NullReferenceException("Token value is null");
        
        _type = data[0];
        _value = data[1];
    }

    public override string ToString() => _value;
}