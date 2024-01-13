using System.Diagnostics;
using Configuration;
using Configuration.App;
using Configuration.Solver;
using Database.Entities;
using Database.Interfaces;
using File.Interfaces;
using History.Interfaces;
using Shared;
using Solution.Interfaces;
using Task = Shared.Task;

namespace Solution;

public class SolutionService : ISolutionSaver, IAvailableSolutionsService
{
    private readonly IHistoryService _historyService;
    private readonly ISolutionDatabaseService _solutionDatabase;
    private readonly IAppConfiguration _appConfiguration;
    private readonly IFileService _fileService;
    private IAvailableSolutionsSubscriber? _availableSolutionsSubscriber;
    
    public SolutionService(IHistoryService historyService, ISolutionDatabaseService solutionDatabase, IAppConfiguration appConfiguration, IFileService fileService)
    {
        _historyService = historyService;
        _solutionDatabase = solutionDatabase;
        _appConfiguration = appConfiguration;
        _fileService = fileService;
    }

    public void SaveSolution(
        IModelConfiguration initialModelConfiguration,
        ISolverConfiguration initialSolverConfiguration,
        FitnessFunction initialFitness,
        Individual bestIndividual)
    {
        var creationDate = DateTime.Now;
        var solutionPath = CopyTaskAsSolutionToDestination(bestIndividual.Task, creationDate);
        
        var solution = new SolutionEntity(
            initialModelConfiguration.ToString(),
            initialSolverConfiguration.ToString(),
            _historyService.GetHistory(),
            bestIndividual.ProgramString,
            initialFitness.ToEntity(),
            bestIndividual.Task.SolutionToEntity(solutionPath),
            creationDate.ToUniversalTime()
        );
        
        _solutionDatabase.Create(solution);
    }

    public void Subscribe(IAvailableSolutionsSubscriber subscriber)
    {
        _availableSolutionsSubscriber = subscriber;
    }

    public void Unsubscribe(IAvailableSolutionsSubscriber subscriber)
    {
        _availableSolutionsSubscriber = null;
    }

    public void FetchAllSubscribed()
    {
        _availableSolutionsSubscriber?.AvailableSolutionsUpdate(_solutionDatabase.FetchAll());
    }

    public void InspectSolution(SolutionEntity solution)
    {
        var solutionPath = GetSolutionPath(solution);
        
        if (_fileService.DoesFileExist(solutionPath) is false)
        {
            _fileService.SaveAsJson<Task>(solution.SolvedTask.Json, solutionPath);
        }
        
        try
        {
            Process.Start(_appConfiguration.TaskOpener, solutionPath);
        }
        catch (Exception e)
        {
        }
    }

    public void RemoveSolution(SolutionEntity solution)
    {
        var solutionPath = GetSolutionPath(solution);
        _fileService.DeleteAt(solutionPath);
        
        _solutionDatabase.Delete(solution);
        _availableSolutionsSubscriber?.AvailableSolutionsUpdate(_solutionDatabase.FetchAll());
    }

    private string CopyTaskAsSolutionToDestination(Task task, DateTime creationDate)
    {
        var destinationPath = GetSolutionPath(task.TaskName, creationDate);
        _fileService.SaveAsJson(task, destinationPath);
        return destinationPath;
    }

    private string GetSolutionPath(SolutionEntity solutionEntity)
    {
        var name = solutionEntity.ToString();
        return Path.Combine(_appConfiguration.SolutionsPath, name + ".json");
    }

    private string GetSolutionPath(string taskName, DateTime creationDate)
    {
        var name = SolutionEntity.ToString(taskName, creationDate);
        return Path.Combine(_appConfiguration.SolutionsPath, name + ".json");
    }
}