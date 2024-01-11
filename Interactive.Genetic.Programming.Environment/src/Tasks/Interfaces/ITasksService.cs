using Database.Entities;
using Task = Solver.Task;

namespace Tasks.Interfaces;

public interface ITasksService
{
    public void SaveTask(string taskName, string taskPath);
    public void ActivateTask(TaskEntity task);
    public void ResetTask();
    public bool IsTaskActive();
    public Task GetTask();
}