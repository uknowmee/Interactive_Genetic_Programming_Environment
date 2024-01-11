using System.Text;
using History.Interfaces;

namespace History;

public class HistoryService : IHistoryService, IHistoryPublisher
{
    private readonly StringBuilder _history = new();
    private IHistorySubscriber? _subscriber;
    
    public void PushEntry(string entry)
    {
        _history.AppendLine(entry);
        _subscriber?.OnHistoryUpdate(entry);
    }

    public void Clear()
    {
        _history.Clear();
        _subscriber?.OnHistoryClear();
    }

    public string GetHistory()
    {
        return _history.ToString();
    }

    public void Subscribe(IHistorySubscriber subscriber)
    {
        _subscriber = subscriber;
    }

    public void Unsubscribe(IHistorySubscriber subscriber)
    {
        _subscriber = null;
    }
}