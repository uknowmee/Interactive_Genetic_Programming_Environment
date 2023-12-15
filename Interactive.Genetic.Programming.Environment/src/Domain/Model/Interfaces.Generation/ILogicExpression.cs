namespace Model.Interfaces.Generation;

public enum LogicExpressionChild
{
    CompExpression,
    BoolExpression
}

public interface ILogicExpression
{
    public double NextLogicBooleanExpressionChance { get; init; }
    public void AddLogicExpression();
}