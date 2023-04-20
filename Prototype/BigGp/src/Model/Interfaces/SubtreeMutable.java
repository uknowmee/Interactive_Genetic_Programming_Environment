package Model.Interfaces;

import Model.BaseNodes.Assignment.Assignment;

public interface SubtreeMutable {

    public void subtreeMutate();

    public default boolean isMutable() {
        return !(this instanceof Assignment assignment) || assignment.getRead() == null;
    }
}
