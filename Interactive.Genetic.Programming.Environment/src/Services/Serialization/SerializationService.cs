using System.Globalization;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;
using Serialization.Interfaces;
using Shared;
using Shared.Interfaces;
using Task = Shared.Task;

namespace Serialization;

public class SerializationService : ISerializationService
{
    private const char InputIndicator = 'i';
    private const char OutputIndicator = 'o';
    private const char ProgramOutputIndicator = 'p';
    private const string CsvDelimiter = ",";

    private const string EmptyString = "null";

    private readonly ILogger<SerializationService> _logger;

    public SerializationService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<SerializationService>();
    }

    public object DeserializeTo<T>(string csvContent) where T : ICsvSerializable
    {
        if (typeof(T) == typeof(Task))
        {
            return FromCsv(csvContent);
        }

        throw new Exception("Unsupported type");
    }

    public string Serialize<T>(T csvSerializable) where T : ICsvSerializable
    {
        if (csvSerializable is Task task)
        {
            return ToCsv(task);
        }

        throw new Exception("Unsupported type");
    }

    private Task FromCsv(string csvContent)
    {
        _logger.LogInformation("Parsing CSV content");

        using var reader = new TextFieldParser(new StringReader(csvContent));
        reader.TextFieldType = FieldType.Delimited;
        reader.Delimiters = [CsvDelimiter];

        var headers = reader.ReadFields() ?? throw new Exception("Failed to read CSV headers");
        var numOfInputs = headers.Count(i => i.Contains(InputIndicator));
        var numOfOutputs = headers.Count(i => i.Contains(OutputIndicator));
        var numOfProgramOutputs = headers.Count(i => i.Contains(ProgramOutputIndicator));

        if (numOfInputs == 0 && numOfOutputs == 0)
        {
            throw new Exception("No inputs / outputs found");
        }

        var task = new Task
        {
            InputLength = numOfInputs == 0 ? 1 : numOfInputs
        };

        while (reader.EndOfData is false)
        {
            var fields = reader.ReadFields() ?? throw new Exception("Failed to read CSV fields");
            var testCase = new TestCase();

            for (var i = 0; i < numOfInputs; i++)
            {
                testCase.Input.Values.Add(ParseDouble(fields[i]));
            }

            for (var i = numOfInputs; i < numOfInputs + numOfOutputs; i++)
            {
                testCase.Output.Values.Add(ParseDouble(fields[i]));
            }
            
            for (var i = numOfInputs + numOfOutputs; i < numOfInputs + numOfOutputs + numOfProgramOutputs; i++)
            {
                testCase.ProgramOutput.Values.Add(ParseDouble(fields[i]));
            }

            task.TestCases.Add(testCase);
        }

        _logger.LogInformation("CSV content parsed successfully");
        return task;
    }

    private string ToCsv(Task task)
    {
        _logger.LogInformation("Parsing task to CSV content");

        var csv = new StringBuilder();
        
        var numOfInputs = task.TestCases.Select(testCase => testCase.Input.Values.Count).Max();
        var numOfOutputs = task.TestCases.Select(testCase => testCase.Output.Values.Count).Max();
        var numOfProgramOutputs = task.TestCases.Select(testCase => testCase.ProgramOutput.Values.Count).Max();
        
        var headers = new List<string>();
        
        for (var i = 0; i < numOfInputs; i++)
        {
            headers.Add($"{InputIndicator}{i}");
        }
        
        for (var i = 0; i < numOfOutputs; i++)
        {
            headers.Add($"{OutputIndicator}{i}");
        }
        
        for (var i = 0; i < numOfProgramOutputs; i++)
        {
            headers.Add($"{ProgramOutputIndicator}{i}");
        }
        
        csv.AppendLine(string.Join(CsvDelimiter, headers));
        
        foreach (var testCase in task.TestCases)
        {
            var values = new List<string>();
            
            for (var i = 0; i < numOfInputs; i++)
            {
                values.Add(testCase.Input.Values.Count > i ? testCase.Input.Values[i].ToString(CultureInfo.InvariantCulture) : EmptyString);
            }
            
            for (var i = 0; i < numOfOutputs; i++)
            {
                values.Add(testCase.Output.Values.Count > i ? testCase.Output.Values[i].ToString(CultureInfo.InvariantCulture) : EmptyString);
            }
            
            for (var i = 0; i < numOfProgramOutputs; i++)
            {
                values.Add(testCase.ProgramOutput.Values.Count > i ? testCase.ProgramOutput.Values[i].ToString(CultureInfo.InvariantCulture) : EmptyString);
            }
            
            csv.AppendLine(string.Join(CsvDelimiter, values));
        }

        _logger.LogInformation("Parsing finished successfully");
        return csv.ToString();
    }

    private static double ParseDouble(string value)
    {
        return double.Parse(string.IsNullOrEmpty(value) ? "0" : value);
    }
}