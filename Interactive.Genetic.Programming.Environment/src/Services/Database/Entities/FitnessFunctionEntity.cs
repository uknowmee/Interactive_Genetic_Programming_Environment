using System.ComponentModel.DataAnnotations.Schema;
using Shared;

namespace Database.Entities;

[ComplexType]
public class FitnessFunctionEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    [Obsolete("Only for EF")]
    public FitnessFunctionEntity()
    {
    }
    
    public FitnessFunctionEntity(string fitnessName, string fitnessCode)
    {
        Name = fitnessName;
        Code = fitnessCode;
    }

    public override string ToString()
    {
        return Name;
    }
}

public static partial class MappingExtensions
{
    public static FitnessFunctionEntity ToEntity(this FitnessFunction fitnessFunction)
    {
        return new FitnessFunctionEntity(fitnessFunction.Name, fitnessFunction.Code);
    }
}