using Shared;

namespace Database.Entities;

public class SolutionFitnessFunction : FitnessFunctionEntity
{
    public Guid Hash { get; set; }
    
    public int SolutionEntityId { get; set; }
    public SolutionEntity SolutionEntity { get; set; }

    [Obsolete("Only for EF")]
    public SolutionFitnessFunction()
    {
    }
    
    public SolutionFitnessFunction(string name, string code, Guid hash): base(name, code)
    {
        Hash = hash;
    }
    
    public override string ToString()
    {
        return $"{Name} - {Hash}";
    }
}

public static partial class MappingExtensions
{
    public static SolutionFitnessFunction ToEntity(this FitnessFunction fitnessFunction)
    {
        return new SolutionFitnessFunction(fitnessFunction.Name, fitnessFunction.Code, fitnessFunction.Hash);
    }
}