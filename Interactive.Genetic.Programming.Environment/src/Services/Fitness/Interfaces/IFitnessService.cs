using Database.Entities;
using Shared;

namespace Fitness.Interfaces;

public interface IFitnessChangeSubscriber
{
    public void OnFitnessFunctionChange(FitnessFunction fitnessFunction);
}

public interface IFitnessService
{
    public void SaveFitness(string fitnessName, string fitnessCode);
    public void ActivateFitness(FitnessFunctionEntity fitnessFunction);
    public void ResetFitness();
    public bool IsFitnessActive();
    public FitnessFunction GetFitnessFunction();
    public void Subscribe(IFitnessChangeSubscriber subscriber);
    public void Unsubscribe(IFitnessChangeSubscriber subscriber);
    void RemoveFitness(FitnessFunctionEntity fitnessFunction);
}