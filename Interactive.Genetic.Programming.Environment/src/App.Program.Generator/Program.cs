﻿using System.Diagnostics;
using App.Program.Generator;
using Configuration.Solver;
using Interpreter;
using Interpreter.Exceptions;
using Strategies.Evolution;
using Utils;

const int capacity = 10000;
var inputs = new List<double> { 0.0, 2.0, 3.0 };
var loopCounter = 0;
var programs = new List<Model.Nodes.Big.Program.Root.Program>(capacity);
var programsCopy = new List<Model.Nodes.Big.Program.Root.Program>(capacity);

Console.Out.WriteLine("Starting to create programs");
var stopwatch = Stopwatch.StartNew();
for (var i = 0; i < capacity; i++)
{
    var program = new Model.Nodes.Big.Program.Root.Program(3);
    program.AddBigNodes();
    programs.Add(program);
    if ((i + 1) % 1000 == 0)
    {
        Console.Out.WriteLine($"Created {i + 1} programs");
    }
}
stopwatch.Stop();
var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
Console.WriteLine($"Total seconds for creation: {elapsedTotalSeconds}");

Console.Out.WriteLine("Starting to copy programs");
stopwatch = Stopwatch.StartNew();
for (var i = 0; i < capacity; i++)
{
    programsCopy.Add(programs[i].Copy());
    if ((i + 1) % 1000 == 0)
    {
        Console.Out.WriteLine($"Copied {i + 1} programs");
    }
}
stopwatch.Stop();
elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
Console.WriteLine($"Total seconds for copying: {elapsedTotalSeconds}");

Console.Out.WriteLine("Starting to run programs");
stopwatch = Stopwatch.StartNew();
var interpreter = new InterpreterService(new SolverConfiguration());
for (var i = 0; i < capacity; i++)
{
    try
    {
        interpreter.Feed(programsCopy[i].ToString());
        interpreter.Run([..inputs]);
    }
    catch (ExecutionTimeExceededException)
    {
        loopCounter++;
    }
    catch (Exception e)
    {
        Console.Out.WriteLine(programsCopy[i]);
        Console.WriteLine(e);
    }
    if ((i + 1) % 1000 == 0)
    {
        Console.Out.WriteLine($"Ran {i + 1} programs. {loopCounter} loops.");
    }
}
stopwatch.Stop();
elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
Console.WriteLine($"Total seconds: {elapsedTotalSeconds}");

Console.Out.WriteLine("Finished");

var avgLength = programsCopy.Average(p => p.Length);
Console.Out.WriteLine($"Average length: {avgLength}");