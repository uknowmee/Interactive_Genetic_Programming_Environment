namespace Database.Entities;

public class FitnessFunctionEntity : FitnessFunctionEntityBase
{
    [Obsolete("Only for EF")]
    public FitnessFunctionEntity()
    {
    }
    
    public FitnessFunctionEntity(string fitnessName, string fitnessCode): base(fitnessName, fitnessCode)
    {
    }

    public override string ToString()
    {
        return Name;
    }
}