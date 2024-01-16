using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Shared.Exceptions;

namespace Shared;

public class FitnessFunction
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid Hash { get; } = Guid.NewGuid();

    private const string TypeName = "CustomFitness.FitnessFunction";
    private const string FitnessFunctionName = "Evaluate";
    private readonly Type? _type;
    private readonly object _instance;

    public FitnessFunction(string fitnessFunctionName, string fitnessFunctionCode)
    {
        Name = fitnessFunctionName;
        Code = fitnessFunctionCode;

        var tree = CSharpSyntaxTree.ParseText(fitnessFunctionCode);

        var assemblyName = Path.GetRandomFileName();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var references = assemblies
            .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
            .Select(a => MetadataReference.CreateFromFile(a.Location))
            .ToArray();

        var compilation = CSharpCompilation.Create(
            assemblyName,
            new[] { tree },
            references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );

        using var memoryStream = new MemoryStream();
        var result = compilation.Emit(memoryStream);

        AssureSuccess(result);

        memoryStream.Seek(0, SeekOrigin.Begin);
        var assembly = Assembly.Load(memoryStream.ToArray());

        _type = assembly.GetType(TypeName) ?? throw new Exception("Type not found");
        _instance = Activator.CreateInstance(_type) ?? throw new Exception("Unable to create instance");
    }

    public object? Run(object?[]? args)
    {
        try
        {
            return _type?.InvokeMember(FitnessFunctionName,
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                _instance,
                args
            );
        }
        catch (Exception e)
        {
            throw new ErrorDuringFitnessFunctionExecution("Error during fitness function execution", e);
        }
    }

    private static void AssureSuccess(EmitResult result)
    {
        if (result.Success) return;

        var failures = result.Diagnostics.Where(diagnostic =>
            diagnostic.IsWarningAsError ||
            diagnostic.Severity == DiagnosticSeverity.Error
        );

        var errors = failures.Select(diagnostic => $"{diagnostic.Id}: {diagnostic.GetMessage()}");
        var message = string.Join(Environment.NewLine, errors);
        throw new CustomException(message);
    }
}