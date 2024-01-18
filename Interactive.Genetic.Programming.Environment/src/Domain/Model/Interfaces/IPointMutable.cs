using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Interfaces;

public interface IPointMutable
{
    public void Mutate();

    public sealed bool IsMutable()
    {
        if (this is not VarExpression varExpression) return true;

        return varExpression.ParentNode switch
        {
            Assignment assignment when assignment.Variable == varExpression => false,
            ForAssignment forAssignment => forAssignment.Variable != varExpression,
            _ => true
        };
    }
}