package Data;

import java.util.ArrayList;
import java.util.List;

public class Vector implements IVector{
    private List<Double> values;

    public Vector() {
        values = new ArrayList<>();
    }

    @Override
    public List<Double> getValues() {
        return this.values;
    }

    @Override
    public void addValue(double value) {
        values.add(value);
    }

    @Override
    public int size() {
        return values.size();
    }

    @Override
    public void clear() {
        values.clear();
    }
}
