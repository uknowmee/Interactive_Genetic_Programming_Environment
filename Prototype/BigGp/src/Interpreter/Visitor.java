package Interpreter;

import Interpreter.Interpreter.EdWardBaseVisitor;
import Interpreter.Interpreter.EdWardParser;
import com.sun.jdi.VMOutOfMemoryException;

import java.sql.Struct;
import java.util.*;

public class Visitor extends EdWardBaseVisitor<Object> {
    private List<Double> input;
    private List<Double> programOutput;

    private long startTime;
    private int lastLine;
    private LinkedHashMap<String, Object> variables;
    private List<Scope> scopes;


    public List<Double> getProgramOutput() {
        return programOutput;
    }

    private String addScope() {
        Scope scope = new Scope(scopes.size());
        String scopeName = String.valueOf(scope.scopeName());

        scopes.add(scope);
        variables.put(scopeName, scope);

        return scopeName;
    }

    private void scopeRemove(String scopeName) {
        var keys = this.variables.keySet().stream().toList();
        String key;
        for (int i = keys.size() - 1; i >= 0; i--) {
            key = keys.get(i);
            this.variables.remove(key);
            if (key.equals(scopeName)) {
                this.scopes.remove(this.scopes.size() - 1);
                break;
            }
        }
    }

    private void timeChecker() {
//        TODO: UNCOMMENT THIS LATER!!!!!
        if (System.currentTimeMillis() - this.startTime > 10) {
            throw new RuntimeException();
        }
    }

    @Override
    public Object visitLine(EdWardParser.LineContext ctx) {
        lastLine += 1;

        timeChecker();

        return visitChildren(ctx);
    }

    @Override
    public String visitAssignment(EdWardParser.AssignmentContext ctx) {
        String name = ctx.IDENTIFIER().toString();

        if (!this.variables.containsKey(name)) {
            this.variables.put(name, 0);
        }

        this.variables.put(name, this.visit(ctx.expression()));
        return name;
    }

    @Override
    public Object visitFunctionCall(EdWardParser.FunctionCallContext ctx) {
        String functionName = ctx.IDENTIFIER().toString();

        switch (functionName) {
            case "read" -> {
                return input.size() > 0 ? input.remove(0) : 0;
            }
            case "write" -> {
                List<EdWardParser.ExpressionContext> params = this.visitParameters(ctx.parameters());
                this.programOutput.add((Double) this.visit(params.get(0)));
                return null;
            }
            default -> {
                return null;
            }
        }
    }

    @Override
    public Object visitIdentifierExpression(EdWardParser.IdentifierExpressionContext ctx) {
        String name = ctx.IDENTIFIER().toString();

        if (!this.variables.containsKey(name)) {
            this.variables.put(name, 0.0);
        }

        return this.variables.get(name);
    }

    @Override
    public List<EdWardParser.ExpressionContext> visitParameters(EdWardParser.ParametersContext ctx) {
        return new ArrayList<>(ctx.expression());
    }

    @Override
    public Object visitConstantExpression(EdWardParser.ConstantExpressionContext ctx) {
        return Double.parseDouble(ctx.getText());
    }

    @Override
    public Double visitAdditiveExpression(EdWardParser.AdditiveExpressionContext ctx) {
        Object left = this.visit(ctx.expression(0));
        Object right = this.visit(ctx.expression(1));
        String operator = ctx.addOp().getText();

        switch (operator) {
            case "+" -> {
                return (Double) left + (Double) right;
            }
            case "-" -> {
                return (Double) left - (Double) right;
            }
            default -> {
//                Should never happen
                return Double.parseDouble("0");
            }
        }
    }

    @Override
    public Double visitMultiplicativeExpression(EdWardParser.MultiplicativeExpressionContext ctx) {
        Object left = this.visit(ctx.expression(0));
        Object right = this.visit(ctx.expression(1));
        String operator = ctx.multOp().getText();

        switch (operator) {
            case "*" -> {
                return (Double) left * (Double) right;
            }
            case "/" -> {
                if (Math.abs((Double) right) <= 0.001) {
                    return (Double) left;
                } else {
                    return (Double) left / (Double) right;
                }
            }
            default -> {
//                Should never happen
                return Double.parseDouble("0");
            }
        }
    }

    @Override
    public Boolean visitComparisonExpression(EdWardParser.ComparisonExpressionContext ctx) {
        Object left = this.visit(ctx.expression(0));
        Object right = this.visit(ctx.expression(1));
        String operator = ctx.compareOp().getText();

        switch (operator) {
            case "==" -> {
                return left.equals(right);
            }
            case "!=" -> {
                return !Objects.equals(left, right);
            }
            case ">" -> {
                return (Double) left > (Double) right;
            }
            case "<" -> {
                return (Double) left < (Double) right;
            }
            case ">=" -> {
                return (Double) left >= (Double) right;
            }
            case "<=" -> {
                return (Double) left <= (Double) right;
            }
            default -> {
//                Should never happen
                return false;
            }
        }
    }

    @Override
    public Object visitParenthesizedExpression(EdWardParser.ParenthesizedExpressionContext ctx) {
        return this.visit(ctx.expression());
    }

    @Override
    public Boolean visitNotExpression(EdWardParser.NotExpressionContext ctx) {
        return !(Boolean) this.visit(ctx.expression());
    }

    @Override
    public Void visitForStatement(EdWardParser.ForStatementContext ctx) {
        String scopeName = this.addScope();
        String iterName = this.visitAssignment(ctx.assignment());
        Double iterValue;
        String operation = ctx.children.get(6).getText();

        String incrementName = "";
        Double incrementValue = 0.0;
        try {
            incrementName = ctx.IDENTIFIER().getText();
        } catch (Exception e) {
            incrementValue = Double.valueOf(ctx.INTEGER().getText());
        }

        while ((Boolean) this.visit(ctx.expression())) {
            this.visit(ctx.block());

            iterValue = (Double) this.variables.get(iterName);
            if (!Objects.equals(incrementName, "")) {
                incrementValue = (Double) this.variables.get(incrementName);
            }

            switch (operation) {
                case "+" -> {
                    this.variables.put(iterName, iterValue + incrementValue);
                }
                case "-" -> {
                    this.variables.put(iterName, iterValue - incrementValue);
                }
            }

            if (ctx.block().children.size() == 2) {
                timeChecker();
            }
        }

        this.scopeRemove(scopeName);
        return null;
    }

    @Override
    public Void visitIfStatement(EdWardParser.IfStatementContext ctx) {
        if ((Boolean) this.visit(ctx.expression())) {
            String scopeName = this.addScope();
            this.visit(ctx.block());
            this.scopeRemove(scopeName);
        }
        return null;
    }

    @Override
    public Boolean visitBooleanExpression(EdWardParser.BooleanExpressionContext ctx) {
        Object left = this.visit(ctx.expression(0));
        Object right = this.visit(ctx.expression(1));
        String operator = ctx.boolOp().getText();

        switch (operator) {
            case "and" -> {
                return (boolean) left && (boolean) right;
            }
            case "or" -> {
                return (boolean) left || (boolean) right;
            }
            default -> {
//                Should never happen
                return false;
            }
        }
    }

    public Visitor(List<Double> input) {
        super();
        this.input = new ArrayList<>(input);
        this.programOutput = new ArrayList<>();
        this.lastLine = 0;
        this.variables = new LinkedHashMap<>();
        this.scopes = new ArrayList<>();

        this.startTime = System.currentTimeMillis();
    }
}
