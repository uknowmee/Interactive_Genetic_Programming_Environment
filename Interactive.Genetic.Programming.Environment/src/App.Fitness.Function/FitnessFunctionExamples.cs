using System;
using System.Linq;
using Shared.Interfaces;

namespace App.Fitness.Function;

public class FitnessFunctionExamples
{
    public static double Evaluate_11a_11b(IEvaluable individual)
    {
        double fitness = 0;
        var diff = 1e34;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count == 0)
            {
                fitness -= 1000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                foreach (var value in programOutput)
                {
                    if (Math.Abs(output[0] - value) < diff)
                    {
                        diff = Math.Abs(output[0] - value);
                    }
                }

                fitness -= diff;
            }
        }

        return fitness;
    }

    public static double Evaluate_11c(IEvaluable individual)
    {
        double fitness = 0;
        var diff = 1e34;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count == 0)
            {
                fitness -= 90000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                foreach (var value in programOutput)
                {
                    if (Math.Abs(output[0] - value) < diff)
                    {
                        diff = Math.Abs(output[0] - value);
                    }
                }

                fitness -= diff;
            }
        }

        return fitness;
    }

    public static double Evaluate_11d_11e(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count == 0)
            {
                fitness -= 1000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                fitness -= (programOutput.Count - 1) * 20;
                var diff = Math.Abs(output[0] - programOutput[0]);
                if (diff > 1)
                {
                    fitness -= individual.ProgramLength;
                }

                fitness -= diff;
            }
        }

        return fitness;
    }

    public static double Evaluate_11f(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count != 1)
            {
                fitness -= 1000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                var diff = Math.Abs(output[0] - programOutput[0]);
                if (diff > 0.1)
                {
                    fitness -= individual.ProgramLength;
                }

                fitness -= diff;
            }
        }

        return fitness;
    }

    public static double Evaluate_12a_12b_12c_12d_f11(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count == 0)
            {
                fitness -= 1000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                fitness -= (programOutput.Count - 1) * 20;
                fitness -= Math.Abs(output[0] - programOutput[0]);
            }
        }

        return fitness;
    }

    public static double Evaluate_12e(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count == 0)
            {
                fitness -= 1000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                fitness -= (programOutput.Count - 1) * 20;

                var val = Math.Abs(programOutput[0]) < 0.001
                    ? Math.Abs(output[0] - programOutput[0])
                    : Math.Abs(1 - output[0] / programOutput[0]);

                if (fitness > -400000)
                {
                    fitness -= val;
                }
            }
        }

        return fitness;
    }

    public static double Evaluate_13a(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (output.Count == 0)
            {
                fitness -= 1000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                fitness -= (programOutput.Count - 1) * 20;
                if (fitness > -400000)
                {
                    fitness -= Math.Abs(output[0] - programOutput[0]) / Math.Abs(output[0]);
                }
            }
        }

        return fitness;
    }

    public static double Evaluate_13b(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count == 0)
            {
                fitness -= 1000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                fitness -= (programOutput.Count - 1) * 20;
                if (fitness > -400000)
                {
                    fitness -= Math.Abs(1 - output[0] / programOutput[0]);
                }
            }
        }

        return fitness;
    }

    public static double Evaluate_14a(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count == 0)
            {
                fitness -= 2000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                fitness -= (programOutput.Count - 1) * 20;
                if (fitness > -400000)
                {
                    fitness -= Math.Abs(output[0] - programOutput[0]);
                }
            }
        }

        return fitness;
    }

    public static double Evaluate_f21(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count != 2)
            {
                fitness -= 2000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                for (var i = 0; i < 2; i++)
                {
                    fitness -= Math.Abs(output[i] - programOutput[i]);
                }
            }
        }

        return fitness;
    }

    public static double Evaluate_f31(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;
        }

        return fitness;
    }

    public static double Evaluate_f32(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count != 1)
            {
                fitness -= 2000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                fitness -= Math.Abs(output[0] - programOutput[0]);
            }
        }
        
        var distinct = individual.TestCases.SelectMany(x => x.Predicted).Distinct().Count();
        if (distinct == 1)
        {
            fitness -= 10000;
        }

        return fitness;
    }

    public static double Evaluate_f41(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count != 1 || !(programOutput.Contains(0.0) || programOutput.Contains(1.0)))
            {
                fitness -= 2000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                if (fitness > -400000)
                {
                    fitness -= Math.Abs(output[0] - programOutput[0]);
                }
            }
        }

        return fitness;
    }

    public static double Evaluate_f42(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count != 1 || !(programOutput.Contains(0.0) || programOutput.Contains(1.0)))
            {
                fitness -= 2000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                if (fitness > -400000)
                {
                    fitness -= Math.Abs(output[0] - programOutput[0]);
                }
            }
        }

        return fitness;
    }

    public static double Evaluate_f43(IEvaluable individual)
    {
        double fitness = 0;

        foreach (var testCase in individual.TestCases)
        {
            var input = testCase.Input;
            var output = testCase.Output;
            var programOutput = testCase.Predicted;

            if (programOutput.Count != 1 || !(programOutput.Contains(0.0) || programOutput.Contains(1.0)))
            {
                fitness -= 2000;
                fitness -= individual.ProgramLength * 5;
            }
            else
            {
                if (fitness > -400000)
                {
                    if (input[2] != 1.0 && programOutput[0] == 1.0)
                    {
                        fitness -= 20;
                    }

                    if (!(input[0] == 1 || input[1] == 1) && programOutput[0] == 1)
                    {
                        fitness -= 10;
                    }

                    fitness -= Math.Abs(output[0] - programOutput[0]) * 5;
                }
            }
        }

        return fitness;
    }
}