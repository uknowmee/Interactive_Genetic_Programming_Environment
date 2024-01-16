using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities;

public class FitnessFunctionEntityBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    
    [Obsolete("Only for EF")]
    public FitnessFunctionEntityBase()
    {
    }
    
    public FitnessFunctionEntityBase(string fitnessName, string fitnessCode)
    {
        Name = fitnessName;
        Code = fitnessCode;
    }
}