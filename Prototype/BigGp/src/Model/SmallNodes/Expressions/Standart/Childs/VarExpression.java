package Model.SmallNodes.Expressions.Standart.Childs;

import Utils.Config.BigGpConfig;
import Model.BaseNodes.ForStatement.ForIncrement;
import Model.BaseNodes.FunctionCallOut.FunctionCallOut;
import Model.Interfaces.PointMutable;
import Model.Interfaces.Terminal;
import Model.Node;
import Model.SmallNodes.Expressions.Standart.Expression;
import Serialization.Token;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class VarExpression extends Node implements PointMutable, Terminal {
    private String variableName;

    public String getValue() {
        return variableName;
    }

    @Override
    public void mutate() {
        String oldVar = this.variableName;

        if (this.getParentNode() instanceof ForIncrement || this.getParentNode() instanceof FunctionCallOut) {

            int breaker = 0;
            while (breaker <= 100 && oldVar.equals(this.variableName)) {
                this.variableName = makeVariableName(true);
                breaker += 1;
            }
        } else if (this.getParentNode() instanceof Expression expression) {
            expression.mutateConstantOrVar();
        }
    }

    @Override
    public String toString() {
        return variableName;
    }

    public ArrayList<Node> getChildrenAsNodes() {
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        return nodes;
    }

    public String getVariableName() {
        return variableName;
    }

    private String makeVariableNameExisting() throws RuntimeException {
        ArrayList<VarExpression> variables = getProgramVariables();

        if (variables.size() == 0) {
            throw new RuntimeException("u dont have any variable existing");
        }

        int bound = variables.size();
        int idx = new Random().nextInt(bound);

        return variables.get(idx).variableName;
    }

    private String makeVariableName() {
        ArrayList<VarExpression> variables = getProgramVariables();
        BigGpConfig config = BigGpConfig.readConfig();

        if (variables.size() == 0) {
            return "x_0";
        }

        if (getRandomPercentages() < config.getNewVarExpressionChance()) {
            int idx = 0;

            List<Integer> varIndexes = variables
                    .stream()
                    .map(var -> Integer.parseInt(var.variableName.split("_")[1]))
                    .toList();

            while (varIndexes.contains(idx)) {
                idx += 1;
            }

            return "x_" + idx;
        }

        return variables.get(new Random().nextInt(variables.size())).variableName;
    }

    private String makeVariableName(boolean shouldVarAlreadyExist) throws RuntimeException {
        if (!shouldVarAlreadyExist) {
            int idx = 0;
            List<Integer> varIndexes = getProgramVariables()
                    .stream()
                    .map(var -> Integer.parseInt(var.variableName.split("_")[1]))
                    .toList();

            while (varIndexes.contains(idx)) {
                idx += 1;
            }

            return "x_" + idx;
        }
        return makeVariableNameExisting();
    }

    public VarExpression(Node parentNode) {
        super(parentNode, "VarExpression", true);
        this.variableName = makeVariableName();
        addToProgramVariables(this);
    }

    public VarExpression(Node parentNode, boolean shouldVarAlreadyExist) throws RuntimeException {
        super(parentNode, "VarExpression", true);
        this.variableName = makeVariableName(shouldVarAlreadyExist);

        if (!shouldVarAlreadyExist) {
            addToProgramVariables(this);
        }
    }

    public VarExpression(Node parent, ArrayList<Token> tokens) {
        super(parent, "VarExpression", true);

        this.variableName = tokens.remove(0).getVALUE();
        addToProgramVariables(this);
    }

    public VarExpression(Node parent, boolean shouldVarAlreadyExist, ArrayList<Token> tokens) {
        super(parent, "VarExpression", true);

        this.variableName = tokens.remove(0).getVALUE();

        if (!shouldVarAlreadyExist) {
            addToProgramVariables(this);
        }
    }
}
