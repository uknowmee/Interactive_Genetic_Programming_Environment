package Model.SmallNodes.Expressions.Standart;

import java.util.Random;

public interface AddRandomExpression {

    enum ExpressionChild {
        CONSTANT,
        VAR_EXPRESSION,
        MUL_EXPRESSION,
        ADD_EXPRESSION;
        private static final ExpressionChild[] VALUES = ExpressionChild.class.getEnumConstants();
        private static final int SIZE = VALUES.length;
        private static final Random RANDOM = new Random();
        public static ExpressionChild randomChild()  {
            return VALUES[(RANDOM.nextInt(SIZE))];
        }
    }

    public double getNEXT_TWO_ARG_EXPRESSION_CHANCE();
    public void addRandomExpression();
}
