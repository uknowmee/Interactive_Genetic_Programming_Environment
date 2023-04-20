package Model.Interfaces;

import Model.Node;

public interface Terminal {

    public String getValue();

    public default String getType(){
        return ((Node) this).getNAME();
    }
}
