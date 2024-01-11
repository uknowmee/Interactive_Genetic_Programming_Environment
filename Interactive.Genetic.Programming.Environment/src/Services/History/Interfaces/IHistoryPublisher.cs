namespace History.Interfaces;

public interface IHistorySubscriber
{
    public void OnHistoryUpdate(string update);
    public void OnHistoryClear();
}

public interface IHistoryPublisher
{
    public void Subscribe(IHistorySubscriber subscriber);
    public void Unsubscribe(IHistorySubscriber subscriber);
}