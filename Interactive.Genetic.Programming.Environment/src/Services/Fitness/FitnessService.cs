using Database.Entities;
using Database.Interfaces;
using Fitness.Interfaces;
using History.Interfaces;
using Shared;
using Shared.Exceptions;

namespace Fitness;

public class FitnessService : IFitnessService, IFitnessInformationPublisher, IAvailableFitnessFunctionsService
{
    private readonly IFitnessDatabaseService _fitnessDatabaseService;
    private readonly IHistoryService _historyService;
    
    private IFitnessInformationSubscriber? _fitnessInformationSubscriber;
    private IAvailableFitnessFunctionsSubscriber? _availableFitnessFunctionsSubscriber;
    private IFitnessChangeSubscriber? _fitnessChangeSubscriber;

    private FitnessFunction? _fitnessFunction;
    
    public FitnessService(IFitnessDatabaseService fitnessDatabaseService, IHistoryService historyService)
    {
        _fitnessDatabaseService = fitnessDatabaseService;
        _historyService = historyService;
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
        if (_fitnessFunction?.Name == fitnessFunction.Name)
        {
            return;
        }
        
        _fitnessFunction = new FitnessFunction(fitnessFunction.Name, fitnessFunction.Code);
        
        _historyService.PushEntry("----------------------------------------------------------------------------");
        _historyService.PushEntry($"Fitness function changed: {_fitnessFunction.Name} - {_fitnessFunction.Hash}");
        
        _fitnessInformationSubscriber?.OnFitnessFunctionChange(_fitnessFunction.Name);
        _fitnessChangeSubscriber?.OnFitnessFunctionChange(_fitnessFunction);
    }
    
    public void ResetFitness()
    {
        _fitnessFunction = null;
        _fitnessInformationSubscriber?.OnFitnessFunctionReset();
        _availableFitnessFunctionsSubscriber?.OnFitnessFunctionReset();
    }

    public void SaveFitness(string fitnessName, string fitnessCode)
    {
        _ = new FitnessFunction(fitnessName, fitnessCode);
        
        if (_fitnessDatabaseService.FetchAll().Any(f => f.Name == fitnessName))
        {
            throw new CustomException("Fitness function with this name already exists");
        }
        
        _fitnessDatabaseService.Create(new FitnessFunctionEntity(fitnessName, fitnessCode));
        _availableFitnessFunctionsSubscriber?.AvailableFunctionsUpdate(_fitnessDatabaseService.FetchAll());
    }

    public bool IsFitnessActive()
    {
        return _fitnessFunction != null;
    }

    public FitnessFunction GetFitnessFunction()
    {
        return IsFitnessActive()
            ? _fitnessFunction ?? throw new Exception("Fitness function is null")
            : throw new Exception("Fitness function is not active");
    }

    public void Subscribe(IFitnessChangeSubscriber subscriber)
    {
        _fitnessChangeSubscriber = subscriber;
    }

    public void Unsubscribe(IFitnessChangeSubscriber subscriber)
    {
        _fitnessChangeSubscriber = null;
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

    void IAvailableFitnessFunctionsService.FetchAllSubscribed()
    {
        _availableFitnessFunctionsSubscriber?.AvailableFunctionsUpdate(_fitnessDatabaseService.FetchAll());
    }

    void IFitnessInformationPublisher.FetchAllSubscribed()
    {
        if (IsFitnessActive() && _fitnessFunction is not null)
        {
            _fitnessInformationSubscriber?.OnFitnessFunctionChange(_fitnessFunction.Name);
            return;
        }
        
        _fitnessInformationSubscriber?.OnFitnessFunctionReset();
    }
}