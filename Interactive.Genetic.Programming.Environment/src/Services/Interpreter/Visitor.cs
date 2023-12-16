using System.Collections.Specialized;

namespace Interpreter;

public record Scope(int ScopeName);

public class Visitor : IntGrammarBaseVisitor<object>
{
    public List<double> Outputs { get; private set; } = [];
    private readonly List<double> _inputs;

    private int _lastLine;
    private readonly long _startTime;
    private readonly int DueTime;

    private readonly OrderedDictionary _variables = new(20);
    private readonly List<Scope> _scopes = [];

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

    private void TimeChecker()
    {
        if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - _startTime > DueTime)
        {
            throw new OperationCanceledException();
        }
    }
    
    public override object VisitLine(IntGrammarParser.LineContext context)
    {
        _lastLine += 1;
        TimeChecker();
        return base.VisitLine(context);
    }

    public override string VisitAssignment(IntGrammarParser.AssignmentContext context)
    {
        string name = context.Start.Text;

        if (!_variables.Contains(name))
        {
            _variables.Add(name, 0);
        }

        _variables[name] = Visit(context.expression());
        return name;
    }

    public override object VisitFunctionCall(IntGrammarParser.FunctionCallContext context)
    {
        string functionName = context.Start.Text;

        switch (functionName)
        {
            case "read" when _inputs.Count <=0:
                return 0;
            case "read":
                var input = _inputs[0];
                _inputs.RemoveAt(0);
                return input;
            case "write":
                var parameters = VisitParameters(context.parameters());
                Outputs.Add(Convert.ToDouble(Visit(parameters[0])));
                return 0;
            default:
                return 0;
        }
    }

    public override object VisitIdentifierExpression(IntGrammarParser.IdentifierExpressionContext context)
    {
        string name = context.Start.Text;

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
        var left = Convert.ToDouble(Visit(context.expression(0)));
        var right = Convert.ToDouble(Visit(context.expression(1)));
        string @operator = context.addOp().GetText().ToString();

        switch (@operator)
        {
            case "+":
                return left + right;
            case "-":
                return left - right;
            default:
                return 0;
        }
    }

    public override object VisitMultiplicativeExpression(IntGrammarParser.MultiplicativeExpressionContext context)
    {
        var left = Convert.ToDouble(Visit(context.expression(0)));
        var right = Convert.ToDouble(Visit(context.expression(1)));
        string @operator = context.multOp().GetText().ToString();

        switch (@operator)
        {
            case "*":
                return left * right;
            case "/":
                return Math.Abs(right) < 0.001 ? left : left / right;
            default:
                return 0;
        }
    }

    public override object VisitComparisonExpression(IntGrammarParser.ComparisonExpressionContext context)
    {
        var left = Convert.ToDouble(Visit(context.expression(0)));
        var right = Convert.ToDouble(Visit(context.expression(1)));
        var @operator = context.compareOp().GetText().ToString();

        switch (@operator)
        {
            case "<":
                return left < right;
            case ">":
                return left > right;
            case "<=":
                return left <= right;
            case ">=":
                return left >= right;
            case "==":
                return left.Equals(right);
            case "!=":
                return !left.Equals(right);
            default:
                return false;
        }
    }

    public override object VisitParenthesizedExpression(IntGrammarParser.ParenthesizedExpressionContext context)
        => Visit(context.expression());

    public override object VisitNotExpression(IntGrammarParser.NotExpressionContext context)
        => !(bool)Visit(context.expression());

    public override object VisitForStatement(IntGrammarParser.ForStatementContext context)
    {
        var scopeName = AddScope();
        string iterName = VisitAssignment(context.assignment()).ToString();

        string incrementName = "";
        double incrementValue = 0.0;

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

            var iterValue = Convert.ToDouble(
                _variables[iterName ?? throw new InvalidOperationException()]
                ?? throw new InvalidOperationException()
            );

            if (!string.IsNullOrEmpty(incrementName))
            {
                incrementValue = Convert.ToDouble(_variables[incrementName] ?? throw new InvalidOperationException());
            }

            _variables[iterName] = iterValue + incrementValue;

            if (context.block().children.Count == 2)
            {
                TimeChecker();
            }
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
        string @operator = context.boolOp().GetText();

        switch (@operator)
        {
            case "and":
                return (bool)left && (bool)right;
            case "or":
                return (bool)left || (bool)right;
            default:
                return false;
        }
    }

    public Visitor(List<double> inputs, int dueTime)
    {
        _inputs = inputs;
        DueTime = dueTime;
        _startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}