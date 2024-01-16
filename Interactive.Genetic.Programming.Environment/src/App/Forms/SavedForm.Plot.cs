using System.Diagnostics;
using Database.Entities;
using ScottPlot;

namespace App.Forms;

public partial class SavedForm
{
    private static Plot MakePlot(SolutionEntity solution)
    {
        var plot = new Plot();
        plot.Title($"Fitness: {solution.SolvedTask.Name}");
        plot.XLabel("No. of Generations");
        plot.YLabel("Fitness value");
        
        return plot;
    }

    private static int[] GetXValues(SolutionEntity solution)
    {
        var xValues = new int[solution.FitnessHistory.Count];
        for (var i = 0; i < solution.FitnessHistory.Count; i++)
        {
            xValues[i] = i;
        }

        return xValues;
    }
    
    private static void PrintPlot(SolutionEntity solution)
    {
        var myPlot = MakePlot(solution);
        var xs = GetXValues(solution);
        var ys = solution.FitnessHistory.ToArray();
        myPlot.Add.Scatter(xs, ys);

        var tempFileName = Path.GetTempFileName() + ".png";
        myPlot.SavePng(tempFileName, 1920, 1080);

        using var process = new Process();
        process.EnableRaisingEvents = true;
        process.StartInfo = new ProcessStartInfo
        {
            FileName = tempFileName,
            UseShellExecute = true
        };

        process.Start();
    }

}