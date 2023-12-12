using Interpreter;

const string program = "x_0 = read();\n" +
                       "if ((42 > (9 * (56 * 78)))) {\n" +
                       "\tx_1 = x_0;\n" +
                       "\twrite(x_0);\n" +
                       "}\n" +
                       "x_0 = (((9 * (2 * 45)) - 12) - 9);\n" +
                       "write(x_0);";

const string program2 = "x_0 = read();\n" +
                        "if ((42 > (9 * (56 * 78)))) {\n" +
                        "\tx_1 = x_0;\n" +
                        "\twrite(x_0);\n" +
                        "}\n" +
                        "x_0 = (((9 * (2 * 45)) - 12) - 9);\n" +
                        "for (x_3 = 92, (10 < 20), -x_0) {\n\twrite(x_3);\n}" +
                        "write(x_0);";

var inputs = new List<double> { 0.0, 2.0 };

for (var i = 0; i < 1000; i++)
{
    try
    {
        IInterpreterService interpreter = new InterpreterService(i % 50 == 0
            ? program2
            : program
        );
        interpreter.Run(inputs);

        Console.Out.WriteLine(
            $"{i} Program finished running. " +
            $"{nameof(interpreter.IsFinished)}: {interpreter.IsFinished}. " +
            $"{nameof(interpreter.Outputs)}: {string.Join(", ", interpreter.Outputs)}"
        );
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

return;