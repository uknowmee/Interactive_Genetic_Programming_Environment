package Model.SmallNodes.Expressions.Logic;


import java.util.Random;

public interface AddRandomLogicExpression {

    enum LogicExpressionChild {
        COMP_EXPRESSION,
        BOOL_EXPRESSION;
        private static final LogicExpressionChild[] VALUES = LogicExpressionChild.class.getEnumConstants();
        private static final int SIZE = VALUES.length;
        private static final Random RANDOM = new Random();
        public static LogicExpressionChild randomChild()  {
            return VALUES[(RANDOM.nextInt(SIZE))];
        }
    }

    public double getNEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE();
    public void addRandomLogicExpression();
}
