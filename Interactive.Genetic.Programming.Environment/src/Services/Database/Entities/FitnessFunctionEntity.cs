using System.ComponentModel.DataAnnotations.Schema;
using Shared;

namespace Database.Entities;

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