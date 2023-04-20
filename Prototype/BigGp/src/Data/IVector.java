package Data;

import java.util.List;

public interface IVector {
    public List<Double> getValues();
    public void addValue(double value);
    public int size();
    public void clear();
}
