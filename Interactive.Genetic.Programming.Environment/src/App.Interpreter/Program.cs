using Configuration.Solver;
using Interpreter;

var configuration = new SolverConfiguration
{
    ExecutionTime = 100
};

var program =
    "x_0 = read();\nx_1 = read();\nx_2 = read();\nif ((1<2)) {\n    x_4 = 9;\n\tif ((1<2)) {\n        x_3 = 5;\n\t\twrite(x_1);\n\t}\n\tx_3 = 5;\n\tif ((1<2)) {\n\t\tx_2 = x_0;\n\t\tx_0 = x_3;\n\t\tx_2 = (x_3 - x_0);\n\t\tx_5 = 4;\n\t\tif ((1<2)) {\n\t\t    x_6 = 2;\n\t\t\twrite(x_1);\n\t\t}\n\t}\n\tx_3 = 55;\n}\nwrite(x_2);\nif ((13 <= 30)) {\n\tif ((((7 / 28) / 73) != x_1)) {\n\t\tx_1 = x_1;\n\t}\n}\nif ((x_0 <= x_0)) {\n\tx_2 = x_0;\n\tx_2 = x_0;\n\tx_3 = 55;\n}\nif ((x_0 < 84)) {\n}";

var inputs = new List<double> { 0.0, 2.0, 3.0 };

try
{
    var interpreter = new InterpreterService(configuration);
    interpreter.Feed(program);
    interpreter.Run(inputs);

    Console.Out.WriteLine(
        $"{nameof(interpreter.IsFinished)}: {interpreter.IsFinished}. " +
        $"{nameof(interpreter.Outputs)}: {string.Join(", ", interpreter.Outputs)}"
    );
}
catch (Exception e)
{
    Console.WriteLine(e);
}