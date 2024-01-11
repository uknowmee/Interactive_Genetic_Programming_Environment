﻿using System.Diagnostics;
using System.Text.Json;
using Configuration.App;
using Database.Entities;
using Database.Interfaces;
using File.Interfaces;
using Solver;
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

    private Task? _task;
    
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
        _task = JsonSerializer.Deserialize<Task>(task.Json) ?? throw new Exception("Task is null");
        _task.TaskName = task.Name;
        
        _taskInformationSubscriber?.OnTaskChange(_task.TaskName);
    }

    public void ResetTask()
    {
        _task = null;
        _taskInformationSubscriber?.OnTaskReset();
        _availableTasksSubscriber?.OnTaskReset();
    }

    public void SaveTask(string taskName, string taskPath)
    {
        if (_taskDatabaseService.FetchAll().Any(f => f.Name == taskName))
        {
            throw new CustomException("Task with this name already exists");
        }
        
        if (ReadTask(taskPath) is not { } task) return;

        var destinationPath = CopyTaskToDestination(task, taskName);
        
        _taskDatabaseService.Create(new TaskEntity(taskName, taskPath, destinationPath, task.Json));
        _availableTasksSubscriber?.AvailableTasksUpdate(_taskDatabaseService.FetchAll());
    }

    public bool IsTaskActive()
    {
        return _task != null;
    }

    public Task GetTask()
    {
        return IsTaskActive()
            ? _task ?? throw new Exception("Task is null")
            : throw new Exception("Task is not active");
    }

    public void RemoveTask(TaskEntity task)
    {
        _fileService.DeleteAt(task.Path);
        _taskDatabaseService.Delete(task);
        ResetTask();
        _availableTasksSubscriber?.AvailableTasksUpdate(_taskDatabaseService.FetchAll());
    }

    public void Subscribe(IAvailableTasksSubscriber subscriber)
    {
        _availableTasksSubscriber = subscriber;
    }

    public void Unsubscribe(IAvailableTasksSubscriber subscriber)
    {
        _availableTasksSubscriber = null;
    }

    void IAvailableTasksService.FetchAllSubscribed()
    {
        _availableTasksSubscriber?.AvailableTasksUpdate(_taskDatabaseService.FetchAll());
    }

    void ITaskInformationPublisher.FetchAllSubscribed()
    {
        if (IsTaskActive() && _task is not null)
        {
            _taskInformationSubscriber?.OnTaskChange(_task.TaskName);
            return;
        }
        
        _taskInformationSubscriber?.OnTaskReset();
    }

    public void InspectTask(TaskEntity task)
    {
        var exists = _fileService.DoesFileExist(task.Path);
        if (exists is false)
        {
            _fileService.SaveAsJson<Task>(task.Json, task.Path);
        }
        
        var thread = new Thread(() =>
        {
            try
            {
                Process.Start(_appConfiguration.TaskOpener, task.Path);
            }
            catch (Exception e)
            {
            }
        });

        thread.Start();
    }

    private Task? ReadTask(string taskPath)
    {
        Task? task;
        
        if (_appConfiguration.ReadTaskFromJson)
        {
            task = _fileService.ReadFromJson<Task>(taskPath) as Task;
        }
        else
        {
            task = _fileService.ReadFromCsv<Task>(taskPath) as Task;
        }

        return task;
    }
    
    private string CopyTaskToDestination(Task task, string taskName)
    {
        var destinationPath = Path.Combine(_appConfiguration.TasksPath, taskName + ".json");
        _fileService.SaveAsJson(task, destinationPath);
        return destinationPath;
    }
}