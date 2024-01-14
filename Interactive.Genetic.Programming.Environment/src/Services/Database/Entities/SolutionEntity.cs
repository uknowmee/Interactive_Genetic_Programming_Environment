﻿using System.ComponentModel.DataAnnotations;
using Utils;

namespace Database.Entities;

public class SolutionEntity
{
    public int Id { get; set; }
    public string InitialModelConfiguration { get; set; }
    public string InitialSolverConfiguration { get; set; }
    public string History { get; set; }
    public string BestIndividual { get; set; }
    [Required] public FitnessFunctionEntity InitialFitness { get; set; }
    [Required] public TaskEntity SolvedTask { get; set; }
    public DateTime CreationDate { get; set; }

    [Obsolete("Only for EF")]
    public SolutionEntity()
    {
    }

    public SolutionEntity(
        string initialModelConfiguration,
        string initialSolverConfiguration,
        string history,
        string bestIndividual,
        FitnessFunctionEntity initialFitness,
        TaskEntity solvedTask,
        DateTime creationDate
    )
    {
        InitialModelConfiguration = initialModelConfiguration;
        InitialSolverConfiguration = initialSolverConfiguration;
        History = history;
        BestIndividual = bestIndividual;
        InitialFitness = initialFitness;
        SolvedTask = solvedTask;
        CreationDate = creationDate;
    }

    public override string ToString()
    {
        return ToString(SolvedTask.Name, CreationDate);
    }

    public static string ToString(string name, DateTime creationDate)
    {
        return $"{name}__{creationDate.ToLocalTime().ToLongFormat()}";
    }
}