using System.Collections.Specialized;

namespace Interpreter;

public record Scope(int ScopeName);

public class Visitor : IntGrammarBaseVisitor<object>
{
    public List<double> Outputs { get; private set; } = [];
    private readonly List<double> _inputs;

    private int _lastLine = 0;

    private readonly OrderedDictionary _variables = new();
    private readonly List<Scope> _scopes = [];

    private double PopInput()
    {
        var input = _inputs[0];
        _inputs.RemoveAt(0);
        return input;
    }

    private object PushOutput(IntGrammarParser.FunctionCallContext context)
    {
        var parameters = VisitParameters(context.parameters());
        Outputs.Add((double)Visit(parameters[0]));
        return null;
    }

    private string AddScope()
    {
        var scope = new Scope(_scopes.Count);
        var scopeName = scope.ScopeName.ToString();

        _scopes.Add(scope);
        _variables.Add(scopeName, scope);

        return scopeName;
    }

    private void RemoveScope(string scopeName)
    {
        var keys = _variables.Keys.Cast<string>().ToList();
        for (var i = keys.Count - 1; i >= 0; i--)
        {
            var key = keys[i];
            _variables.Remove(key);
            if (!key.Equals(scopeName)) continue;
            _scopes.RemoveAt(_scopes.Count - 1);
            break;
        }
    }

    public override object VisitLine(IntGrammarParser.LineContext context)
    {
        _lastLine += 1;
        return base.VisitLine(context);
    }

    public override object VisitAssignment(IntGrammarParser.AssignmentContext context)
    {
        var name = context.IDENTIFIER().GetText();

        if (!_variables.Contains(name))
        {
            _variables.Add(name, 0);
        }

        _variables[name] = Visit(context.expression());
        return name;
    }

    public override object VisitFunctionCall(IntGrammarParser.FunctionCallContext context)
    {
        var functionName = context.IDENTIFIER().GetText();

        return (functionName switch
        {
            "read" when _inputs.Count <= 0 => 0,
            "read" => () => PopInput(),
            "write" => PushOutput(context),
            _ => null
        })!;
    }

    public override object VisitIdentifierExpression(IntGrammarParser.IdentifierExpressionContext context)
    {
        var name = context.IDENTIFIER().ToString() ?? string.Empty;

        if (!_variables.Contains(name))
        {
            _variables.Add(name, 0);
        }

        return _variables[name] ?? 0;
    }

    public override List<IntGrammarParser.ExpressionContext> VisitParameters(IntGrammarParser.ParametersContext context)
        => [..context.expression()];

    public override object VisitConstantExpression(IntGrammarParser.ConstantExpressionContext context)
        => double.Parse(context.GetText());

    public override object VisitAdditiveExpression(IntGrammarParser.AdditiveExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var @operator = context.addOp().GetText();

        return @operator switch
        {
            "+" => (double)left + (double)right,
            "-" => (double)left - (double)right,
            _ => 0
        };
    }

    public override object VisitMultiplicativeExpression(IntGrammarParser.MultiplicativeExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var @operator = context.multOp().GetText();

        return @operator switch
        {
            "*" => (double)left * (double)right,
            "/" => Math.Abs((double)right) < 0.001
                ? (double)left
                : (double)left / (double)right,
            _ => 0
        };
    }

    public override object VisitComparisonExpression(IntGrammarParser.ComparisonExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var @operator = context.compareOp().GetText();

        return @operator switch
        {
            "<" => (double)left < (double)right,
            ">" => (double)left > (double)right,
            "<=" => (double)left <= (double)right,
            ">=" => (double)left >= (double)right,
            "==" => ((double)left).Equals((double)right),
            "!=" => !((double)left).Equals((double)right),
            _ => false
        };
    }

    public override object VisitParenthesizedExpression(IntGrammarParser.ParenthesizedExpressionContext context)
        => Visit(context.expression());

    public override object VisitNotExpression(IntGrammarParser.NotExpressionContext context)
        => !(bool)Visit(context.expression());

    public override object VisitForStatement(IntGrammarParser.ForStatementContext context)
    {
        var scopeName = AddScope();
        var iterName = VisitAssignment(context.assignment()).ToString();
        var operation = context.children[6].GetText();

        var incrementName = "";
        var incrementValue = 0.0;

        try
        {
            incrementName = context.IDENTIFIER().GetText();
        }
        catch (Exception)
        {
            incrementValue = double.Parse(context.INTEGER().GetText());
        }

        while ((bool)Visit(context.expression()))
        {
            Visit(context.block());

            var iterValue = (double)(
                _variables[iterName ?? throw new InvalidOperationException()]
                ?? throw new InvalidOperationException()
            );

            if (!string.IsNullOrEmpty(incrementName))
            {
                incrementValue = (double)(_variables[incrementName] ?? throw new InvalidOperationException());
            }

            _variables[iterName] = operation switch
            {
                "+" => iterValue + incrementValue,
                "-" => iterValue - incrementValue,
                _ => _variables[iterName]
            };
        }

        RemoveScope(scopeName);
        return null;
    }

    public override object VisitIfStatement(IntGrammarParser.IfStatementContext context)
    {
        if (!(bool)Visit(context.expression())) return null;

        var scopeName = AddScope();
        Visit(context.block());
        RemoveScope(scopeName);
        return null;
    }

    public override object VisitBooleanExpression(IntGrammarParser.BooleanExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var @operator = context.boolOp().GetText();

        return @operator switch
        {
            "and" => (bool)left && (bool)right,
            "or" => (bool)left || (bool)right,
            _ => false
        };
    }

    public Visitor(List<double> inputs) => _inputs = inputs;
}