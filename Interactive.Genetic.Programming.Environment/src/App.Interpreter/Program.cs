using Interpreter;

// const string program = "x_0 = read();\n" +
//                        "if ((42 > (9 * (56 * 78)))) {\n" +
//                        "\tx_1 = x_0;\n" +
//                        "\twrite(x_0);\n" +
//                        "}\n" +
//                        "x_0 = (((9 * (2 * 45)) - 12) - 9);\n" +
//                        "write(x_0);";
//
// const string program2 = "x_0 = read();\n" +
//                         "if ((42 > (9 * (56 * 78)))) {\n" +
//                         "\tx_1 = x_0;\n" +
//                         "\twrite(x_0);\n" +
//                         "}\n" +
//                         "x_0 = (((9 * (2 * 45)) - 12) - 9);\n" +
//                         "for (x_3 = 92, (10 < 20), -x_0) {\n\twrite(x_3);\n}" +
//                         "write(x_0);";

var program3 =
    "x_0 = read();\nx_1 = read();\nx_2 = read();\nif ((1<2)) {\n    x_4 = 9;\n\tif ((1<2)) {\n        x_3 = 5;\n\t\twrite(x_1);\n\t}\n\tx_3 = 5;\n\tif ((1<2)) {\n\t\tx_2 = x_0;\n\t\tx_0 = x_3;\n\t\tx_2 = (x_3 - x_0);\n\t\tx_5 = 4;\n\t\tif ((1<2)) {\n\t\t    x_6 = 2;\n\t\t\twrite(x_1);\n\t\t}\n\t}\n\tx_3 = 55;\n}\nwrite(x_2);\nif ((13 <= 30)) {\n\tif ((((7 / 28) / 73) != x_1)) {\n\t\tx_1 = x_1;\n\t}\n}\nif ((x_0 <= x_0)) {\n\tx_2 = x_0;\n\tx_2 = x_0;\n\tx_3 = 55;\n}\nif ((x_0 < 84)) {\n}";

var inputs = new List<double> { 0.0, 2.0, 3.0 };

// for (var i = 0; i < 1000; i++)
// {
    try
    {
        // IInterpreterService interpreter = new InterpreterService(i % 50 == 0
        //     ? program2
        //     : program
        // );
        var interpreter = new InterpreterService(program3);
        interpreter.Run(inputs);

        Console.Out.WriteLine(
            // $"{i} Program finished running. " +
            $"{nameof(interpreter.IsFinished)}: {interpreter.IsFinished}. " +
            $"{nameof(interpreter.Outputs)}: {string.Join(", ", interpreter.Outputs)}"
        );
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
// }

return;