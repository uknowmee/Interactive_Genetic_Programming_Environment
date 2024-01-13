using System.Globalization;
using System.Text;
using Configuration.Interfaces;
using History.Interfaces;

namespace History;

public class HistoryService : IHistoryService, IHistoryPublisher, IConfigurationChangeSubscriber
{
    private readonly StringBuilder _history = new();
    
    private IHistorySubscriber? _subscriber;
    private ISolverConfigurationChangePublisher _solverConfigurationChangePublisher;
    
    public HistoryService(ISolverConfigurationChangePublisher solverConfigurationChangePublisher)
    {
        _solverConfigurationChangePublisher = solverConfigurationChangePublisher;
        _solverConfigurationChangePublisher.Subscribe(this);
    }
    
    public void PushEntry(string entry)
    {
        var entryLine = $"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} {entry}{Environment.NewLine}";
        _history.Append(entryLine);
        _subscriber?.OnHistoryUpdate(entryLine);
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

    public void OnSolverConfigurationChanged(string configurationChange)
    {
        PushEntry(configurationChange);
    }
}