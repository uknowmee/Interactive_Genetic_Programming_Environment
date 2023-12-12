namespace Model.Interfaces.Generation;

public enum LogicExpressionChild
{
    CompExpression,
    BoolExpression
}

public interface ILogicExpression
{
    public double NextLogicBooleanExpressionChance();
    public void AddLogicExpression();
}