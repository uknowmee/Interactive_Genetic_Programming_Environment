using Shared;
using Task = Shared.Task;

namespace App.Tasks.Serialisation;

public static class TasksProvider
{
    public static Task GetTask()
    {
        return new Task
        {
            InputLength = 3,
            TaskName = "Test task",
            TestCases =
            [
                new TestCase
                {
                    Input = new Vector { Values = [1, 2, 3] },
                    Output = new Vector { Values = [3, 2, 1] },
                    ProgramOutput = new Vector { Values = [5, 4, 1, 2] }
                },
                new TestCase
                {
                    Input = new Vector { Values = [4, 5, 6] },
                    Output = new Vector { Values = [6, 5, 4] },
                    ProgramOutput = new Vector { Values = [10, 6] }
                },
                new TestCase
                {
                    Input = new Vector { Values = [7, 8, 9] },
                    Output = new Vector { Values = [9, 8, 7] },
                    ProgramOutput = new Vector { Values = [double.NegativeInfinity] }
                }
            ]
        };
    }
}