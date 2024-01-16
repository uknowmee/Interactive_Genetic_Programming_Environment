using App.Tasks.Serialisation;
using File;
using Serialization;
using Task = Shared.Task;

var serializationService = new SerializationService(LoggingConfiguration.Factory);
var fileService = new FileService(LoggingConfiguration.Factory, serializationService);

var taskNames = new List<string>
{
    "11a_1", "11b_1", "11c_1", "11d_1", "11e_1", "11f_1", "12a_200", "12b_200", "12c_1000", "12d_200", "12e_1000", "13a_1000",
    "13b_1000", "14a_200", "f11_200", "f21_2000", "f31_200", "f32_800", "f41_2", "f42_4", "f43_8"
};

foreach (var taskName in taskNames)
{
    var taskJsonName = taskName + ".json";
    var taskCsvName = taskName + ".csv";
    var taskPath =
        @$"D:\projects\Interactive_Genetic_Programming_Environment\Interactive.Genetic.Programming.Environment\tasks\{taskJsonName}";
    var destinationPath =
        @$"D:\projects\Interactive_Genetic_Programming_Environment\Interactive.Genetic.Programming.Environment\tasks_csv\{taskCsvName}";

    var taskFromJson = fileService.ReadFromJson<Task>(taskPath) as Task ?? throw new Exception("Failed to read from json file");
    fileService.SaveAsCsv(taskFromJson, destinationPath);

    var taskFromCsv = fileService.ReadFromCsv<Task>(destinationPath) as Task ?? throw new Exception("Failed to read from csv file");
}