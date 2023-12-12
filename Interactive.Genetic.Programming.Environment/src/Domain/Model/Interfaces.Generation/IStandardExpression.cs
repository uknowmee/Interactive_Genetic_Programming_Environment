﻿namespace Model.Interfaces.Generation;

public enum ExpressionChild
{
    Constant,
    VarExpression,
    MulExpression,
    AddExpression
}

public interface IStandardExpression
{
    public double NextTwoArgExpressionChance { get; set; }
    public void AddStandardExpression();
}