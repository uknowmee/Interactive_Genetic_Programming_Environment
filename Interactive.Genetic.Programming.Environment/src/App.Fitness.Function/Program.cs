using System;
using Shared;

const string text = """
                    using System;
                    using Shared.Interfaces;

                    namespace CustomFitness;

                    public class FitnessFunction
                    {
                        public static double Evaluate(IEvaluable individual)
                        {
                            var fitness = 0.0;
                    
                            foreach (var testCase in individual.TestCases)
                            {
                                var output = testCase.Output;
                                var predicted = testCase.Predicted;
                    
                                if (output.Count == 0)
                                {
                                    fitness -= 1000;
                                    fitness -= individual.ProgramLength * 5;
                                }
                                else
                                {
                                    fitness -= (output.Count - 1) * 20;
                                    if (fitness > -400000)
                                    {
                                        fitness -= Math.Abs(1 - output[0] / predicted[0]);
                                    }
                                }
                            }
                    
                            return fitness;
                        }
                    }
                    """;

var evaluable = new Individual();
var returned1 = new FitnessFunction("1_3_B", text).Run([evaluable]);

evaluable.Task.TestCases[0].ProgramOutput.Values = [1, 2, 3];
var returned2 = new FitnessFunction("1_3_B", text).Run([evaluable]);

evaluable.Task.TestCases[0].ProgramOutput.Values = [2, 3, 4];
var returned3 = new FitnessFunction("1_3_B", text).Run([evaluable]);

Console.Out.WriteLine("Returned1: " + returned1);
Console.Out.WriteLine("Returned2: " + returned2);
Console.Out.WriteLine("Returned3: " + returned3);
Console.Out.WriteLine("Returned: " + CustomFitness.Example.FitnessFunction.Evaluate(evaluable));