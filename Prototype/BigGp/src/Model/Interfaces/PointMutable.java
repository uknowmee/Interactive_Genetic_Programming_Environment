package Model.Interfaces;

import Model.BaseNodes.Assignment.Assignment;
import Model.BaseNodes.ForStatement.ForAssignment;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;

public interface PointMutable {

    public void mutate();

    public default boolean isMutable() {
        if (this instanceof VarExpression var) {

            if (var.getParentNode() instanceof Assignment assignment) {
                if (assignment.getVariable().hashCode() == var.hashCode()) {
                    return false;
                }
            }

            if (var.getParentNode() instanceof ForAssignment forAssignment) {
                return forAssignment.getVariable().hashCode() != var.hashCode();
            }
        }

        return true;
    }
}
