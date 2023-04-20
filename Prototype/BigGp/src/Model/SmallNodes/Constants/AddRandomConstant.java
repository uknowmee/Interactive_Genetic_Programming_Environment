package Model.SmallNodes.Constants;

import java.util.Random;

public interface AddRandomConstant {

    enum RandomConstant {
        INT;
//        STR,
//        BOOL,
//        NULL;
        private static final RandomConstant[] VALUES = RandomConstant.class.getEnumConstants();
        private static final int SIZE = VALUES.length;
        private static final Random RANDOM = new Random();
        public static RandomConstant randomChild()  {
            return VALUES[(RANDOM.nextInt(SIZE))];
        }
    }

    public void addRandomConstant(RandomConstant givenConst);
}
