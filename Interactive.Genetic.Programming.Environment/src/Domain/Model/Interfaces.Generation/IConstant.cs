namespace Model.Interfaces.Generation;

public enum ConstantType
{
    Int,
    // Str,
    // Bool,
    // Null
}

public interface IConstant
{
    public void AddConstant();
}