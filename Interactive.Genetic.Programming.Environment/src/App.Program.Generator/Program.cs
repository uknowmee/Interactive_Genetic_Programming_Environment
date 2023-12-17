using System.Diagnostics;
using Interpreter;
using Interpreter.Exceptions;

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
    if (i % 1000 == 0)
    {
        Console.Out.WriteLine($"Created {i} programs");
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
    if (i % 1000 == 0)
    {
        Console.Out.WriteLine($"Copied {i} programs");
    }
}
stopwatch.Stop();
elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
Console.WriteLine($"Total seconds for copying: {elapsedTotalSeconds}");

Console.Out.WriteLine("Starting to run programs");
stopwatch = Stopwatch.StartNew();
for (var i = 0; i < capacity; i++)
{
    try
    {
        var interpreter = new InterpreterService(programsCopy[i].ToString());
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
    if (i % 1000 == 0)
    {
        Console.Out.WriteLine($"Ran {i} programs. {loopCounter} loops.");
    }
}
stopwatch.Stop();
elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
Console.WriteLine($"Total seconds: {elapsedTotalSeconds}");