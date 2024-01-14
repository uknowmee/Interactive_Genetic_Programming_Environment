using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace LangTests;

public class Compiler
{
    private const string TypeName = "CustomFitness.FitnessFunction";
    private const string FitnessFunctionName = "Evaluate";
    private readonly Type? _type;
    private readonly object _instance;

    public Compiler(string code)
    {
        var tree = CSharpSyntaxTree.ParseText(code);
        
        var assemblyName = Path.GetRandomFileName();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var references = assemblies
            .Where(a => !a.IsDynamic)
            .Select(a => MetadataReference.CreateFromFile(a.Location))
            .ToArray();

        var compilation = CSharpCompilation.Create(
            assemblyName,
            new[] { tree },
            references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );

        using var ms = new MemoryStream();
        var result = compilation.Emit(ms);
        
        AssureSuccess(result);
        
        ms.Seek(0, SeekOrigin.Begin);
        var assembly = Assembly.Load(ms.ToArray());

        _type = assembly.GetType(TypeName) ?? throw new Exception("Type not found");
        _instance = Activator.CreateInstance(_type) ?? throw new Exception("Unable to create instance");
    }
    
    public object? Run(object?[]? args)
    {
        return _type?.InvokeMember(FitnessFunctionName,
            BindingFlags.Default | BindingFlags.InvokeMethod,
            null,
            _instance,
            args
        );
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
        throw new Exception(message);
    }
}