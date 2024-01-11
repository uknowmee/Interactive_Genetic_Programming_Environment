namespace Fitness.Interfaces;

public interface IFitnessInformationSubscriber
{
    public void OnFitnessFunctionChange(string functionName);
    public void OnFitnessFunctionReset();
}

public interface IFitnessInformationPublisher
{
    public void Subscribe(IFitnessInformationSubscriber subscriber);
    public void Unsubscribe(IFitnessInformationSubscriber subscriber);
    void FetchAllSubscribed();
}