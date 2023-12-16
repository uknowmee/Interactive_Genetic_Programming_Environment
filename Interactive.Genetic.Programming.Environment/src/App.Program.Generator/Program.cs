using Interpreter;
using Interpreter.Exceptions;

var inputs = new List<double> { 0.0, 2.0, 3.0 };
var counter = 0;
var loopCounter = 0;

while (true)
{
    var program = new Model.Nodes.Big.Program.Root.Program(3);
    program.AddBigNodes();

    try
    {
        var interpreter = new InterpreterService(program.ToString());
        interpreter.Run([..inputs]);
    }
    catch (ExecutionTimeExceededException)
    {
        loopCounter++;
    }
    catch (Exception e)
    {
        Console.Out.WriteLine(program);
        Console.WriteLine(e);
    }

    counter++;
    if (counter % 100 == 0)
    {
        Console.Out.WriteLine($"Counter: {counter}, LoopCounter: {loopCounter}");
    }
}