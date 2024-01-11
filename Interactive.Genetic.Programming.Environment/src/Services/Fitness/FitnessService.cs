using Database.Entities;
using Database.Interfaces;
using Fitness.Interfaces;
using Solver;

namespace Fitness;

public class FitnessService : IFitnessService, IFitnessInformationPublisher, IAvailableFitnessFunctionsService
{
    private readonly IFitnessDatabaseService _fitnessDatabaseService;
    private IFitnessInformationSubscriber? _fitnessInformationSubscriber;
    private IAvailableFitnessFunctionsSubscriber? _availableFitnessFunctionsSubscriber;
    
    public FitnessService(IFitnessDatabaseService fitnessDatabaseService)
    {
        _fitnessDatabaseService = fitnessDatabaseService;
    }
    
    public void Subscribe(IFitnessInformationSubscriber subscriber)
    {
        _fitnessInformationSubscriber = subscriber;
    }

    public void Unsubscribe(IFitnessInformationSubscriber subscriber)
    {
        _fitnessInformationSubscriber = null;
    }

    public void ActivateFitness(FitnessFunctionEntity fitnessFunction)
    {
        _fitnessInformationSubscriber?.OnFitnessFunctionChange(fitnessFunction.Name);
    }
    
    public void ResetFitness()
    {
        _fitnessInformationSubscriber?.OnFitnessFunctionReset();
        _availableFitnessFunctionsSubscriber?.OnFitnessFunctionReset();
    }

    public void SaveFitness(string fitnessName, string fitnessCode)
    {
        _fitnessDatabaseService.Create(new FitnessFunctionEntity(fitnessName, fitnessCode));
        _availableFitnessFunctionsSubscriber?.AvailableFunctionsUpdate(_fitnessDatabaseService.FetchAll());
    }

    public bool IsFitnessActive()
    {
        throw new NotImplementedException();
    }

    public FitnessFunction GetFitnessFunction()
    {
        throw new NotImplementedException();
    }

    public void RemoveFitness(FitnessFunctionEntity fitnessFunction)
    {
        _fitnessDatabaseService.Delete(fitnessFunction);
        ResetFitness();
        _availableFitnessFunctionsSubscriber?.AvailableFunctionsUpdate(_fitnessDatabaseService.FetchAll());
    }

    public void Subscribe(IAvailableFitnessFunctionsSubscriber subscriber)
    {
        _availableFitnessFunctionsSubscriber = subscriber;
    }

    public void Unsubscribe(IAvailableFitnessFunctionsSubscriber subscriber)
    {
        _availableFitnessFunctionsSubscriber = null;
    }

    public void FetchAllSubscribed()
    {
        _availableFitnessFunctionsSubscriber?.AvailableFunctionsUpdate(_fitnessDatabaseService.FetchAll());
    }
}