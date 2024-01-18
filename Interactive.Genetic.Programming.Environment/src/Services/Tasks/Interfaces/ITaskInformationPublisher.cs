namespace Tasks.Interfaces;

public interface ITaskInformationSubscriber
{
    public void OnTaskChange(string taskName);
    public void OnTaskReset();
}

public interface ITaskInformationPublisher
{
    public void Subscribe(ITaskInformationSubscriber subscriber);
    public void Unsubscribe(ITaskInformationSubscriber subscriber);
    void FetchAllSubscribed();
}