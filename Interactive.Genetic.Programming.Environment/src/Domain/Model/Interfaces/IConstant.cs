namespace Model.Interfaces;

public enum ConstantType
{
    Int,
    // Str,
    // Bool,
    // Null
}

public interface IConstant
{
    public void AddConstant(ConstantType constantType);
}