using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Interfaces.Evolution;

public interface IPointMutable
{
    public void Mutate();

    public sealed bool IsMutable()
    {
        if (this is not VarExpression varExpression) return true;
        
        if (varExpression.ParentNode is Assignment assignment)
        {
            if (assignment.Variable == varExpression)
            {
                return false;
            }
        }
            
        if (varExpression.ParentNode is ForAssignment forAssignment)
        {
            return forAssignment.Variable != varExpression;
        }

        return true;
    }
}