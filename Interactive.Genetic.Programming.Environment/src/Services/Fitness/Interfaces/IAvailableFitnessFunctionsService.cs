using Database.Entities;

namespace Fitness.Interfaces;

public interface IAvailableFitnessFunctionsSubscriber
{
    public void AvailableFunctionsUpdate(IEnumerable<FitnessFunctionEntity> functions);
    void OnFitnessFunctionReset();
}

public interface IAvailableFitnessFunctionsService
{
    public void Subscribe(IAvailableFitnessFunctionsSubscriber subscriber);
    public void Unsubscribe(IAvailableFitnessFunctionsSubscriber subscriber);
    public void FetchAllSubscribed();
}