package Serialization;

public class Token {

    private final String NAME;
    private final String VALUE;

    public String getNAME() {
        return NAME;
    }

    public String getVALUE() {
        return VALUE;
    }

    @Override
    public String toString() {
        return NAME + " " + VALUE;
    }

    public Token(String name, String value) {
        this.NAME = name;
        this.VALUE = value;
    }
}
