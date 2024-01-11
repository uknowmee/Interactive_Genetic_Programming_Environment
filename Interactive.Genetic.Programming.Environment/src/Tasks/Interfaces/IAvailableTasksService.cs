using Database.Entities;

namespace Tasks.Interfaces;

public interface IAvailableTasksSubscriber
{
    public void AvailableTasksUpdate(IEnumerable<TaskEntity> tasks);
    void OnTaskReset();
}

public interface IAvailableTasksService
{
    public void Subscribe(IAvailableTasksSubscriber subscriber);
    public void Unsubscribe(IAvailableTasksSubscriber subscriber);
    public IEnumerable<TaskEntity> FetchAllSubscribed();
}