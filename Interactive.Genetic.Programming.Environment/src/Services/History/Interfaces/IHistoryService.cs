namespace History.Interfaces;

public interface IHistoryService
{
    public void PushEntry(string entry);
    public void Clear();
    public string GetHistory();
}