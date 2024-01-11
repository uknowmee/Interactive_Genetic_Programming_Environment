using Configuration.App;
using Database.Entities;
using Database.Interfaces;
using File.Interfaces;
using Tasks.Interfaces;
using Task = Solver.Task;

namespace Tasks;

public class TasksService : ITasksService, ITaskInformationPublisher, IAvailableTasksService
{
    private readonly ITaskDatabaseService _taskDatabaseService;
    private readonly IFileService _fileService;
    private readonly IAppConfiguration _appConfiguration;
    private ITaskInformationSubscriber? _taskInformationSubscriber;
    private IAvailableTasksSubscriber? _availableTasksSubscriber;
    
    public TasksService(ITaskDatabaseService taskDatabaseService, IFileService fileService, IAppConfiguration appConfiguration)
    {
        _taskDatabaseService = taskDatabaseService;
        _fileService = fileService;
        _appConfiguration = appConfiguration;
    }
    
    public void Subscribe(ITaskInformationSubscriber subscriber)
    {
        _taskInformationSubscriber = subscriber;
    }

    public void Unsubscribe(ITaskInformationSubscriber subscriber)
    {
        _taskInformationSubscriber = null;
    }

    public void ActivateTask(TaskEntity task)
    {
        _taskInformationSubscriber?.OnTaskChange(task.Name);
    }

    public void ResetTask()
    {
        _taskInformationSubscriber?.OnTaskReset();
        _availableTasksSubscriber?.OnTaskReset();
    }

    public void SaveTask(string taskName, string taskPath)
    {
        if (ReadTask(taskPath) is not { } task)
        {
            return;
        }

        var destinationPath = CopyTaskToDestination(task, taskName);
        
        _taskDatabaseService.Create(new TaskEntity(taskName, taskPath, destinationPath, task.Json));
        _availableTasksSubscriber?.AvailableTasksUpdate(_taskDatabaseService.FetchAll());
    }
    
    public bool IsTaskActive()
    {
        throw new NotImplementedException();
    }

    public Task GetTask()
    {
        throw new NotImplementedException();
    }

    public void Subscribe(IAvailableTasksSubscriber subscriber)
    {
        _availableTasksSubscriber = subscriber;
    }

    public void Unsubscribe(IAvailableTasksSubscriber subscriber)
    {
        _availableTasksSubscriber = null;
    }

    public IEnumerable<TaskEntity> FetchAllSubscribed()
    {
        return _taskDatabaseService.FetchAll();
    }
    
    private Task? ReadTask(string taskPath)
    {
        Task? task = null;
        
        if (_appConfiguration.ReadTaskFromJson)
        {
            task = _fileService.ReadFromJson<Task>(taskPath) as Task;
        }

        return task;
    }
    
    private string CopyTaskToDestination(Task task, string taskName)
    {
        var destinationPath = Path.Combine(_appConfiguration.TasksPath, taskName + ".json");
        _fileService.SaveAsJson(task.Json, destinationPath);
        return destinationPath;
    }
}