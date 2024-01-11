using Database.Entities;
using Solver;

namespace Fitness.Interfaces;

public interface IFitnessService
{
    public void SaveFitness(string fitnessName, string fitnessCode);
    public void ActivateFitness(FitnessFunctionEntity fitnessFunction);
    public void ResetFitness();
    public bool IsFitnessActive();
    public FitnessFunction GetFitnessFunction();
    void RemoveFitness(FitnessFunctionEntity fitnessFunction);
}