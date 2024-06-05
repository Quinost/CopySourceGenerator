using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SourceGenerator.Blueprints;
using System.Collections.Generic;
using System.Linq;

namespace SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class CopyGenerator : IIncrementalGenerator
{
    private string FullNamespace = default;

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        if (string.IsNullOrWhiteSpace(PathExtension.Path))
            return;

        context.RegisterSourceOutput(context.CompilationProvider, (sourceContext, compilation) =>
        {
            // Get all record declarations in the compilation
            var records = compilation.SyntaxTrees
                .SelectMany(tree => tree.GetRoot().DescendantNodes())
                .OfType<RecordDeclarationSyntax>();

            ICollection<Blueprint> Blueprints = [];

            var assemblyName = Extensions.GetLastAssemblyName(compilation.AssemblyName);
            FullNamespace = Constants.NamespacePrefix + assemblyName;

            foreach (var record in records)
            {
                var recordBlueprint = new RecordBlueprint(record.Identifier.Text, FullNamespace);

                var semanticModel = compilation.GetSemanticModel(record.SyntaxTree);
                GetParameters(recordBlueprint, record, Blueprints, semanticModel);

                Blueprints.Add(recordBlueprint);
            }

            FileSaver.SaveFiles(Blueprints, assemblyName);
        });

    }

    private void GetParameters(RecordBlueprint recordBlueprint, RecordDeclarationSyntax record, ICollection<Blueprint> blueprints, SemanticModel semanticModel)
    {
        foreach (var parameter in record.ParameterList.Parameters)
        {
            var parameterTypeSymbol = semanticModel.GetTypeInfo(parameter.Type).Type;

            recordBlueprint.AddParameter(GetPropertyType(parameterTypeSymbol), parameter.Identifier.Text);

            GenerateParameters(parameterTypeSymbol, blueprints);
        }
    }

    private void GenerateParameters(ITypeSymbol parameterTypeSymbol, ICollection<Blueprint> blueprints)
    {
        if (parameterTypeSymbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.TypeArguments.Count() != 0)
        {
            foreach(var typeArgument in namedTypeSymbol.TypeArguments)
            {
                Generate(typeArgument);
            }
        }
        else
        {
            Generate(parameterTypeSymbol);
        }

        void Generate(ITypeSymbol typeSymbol)
        {
            if (typeSymbol.TypeKind is TypeKind.Enum)
                GenerateEnumFromParameter(typeSymbol, blueprints);

            if (typeSymbol.IsRecord)
                GenerateRecordFromParameter(typeSymbol, blueprints);
        }
    }

    private void GenerateRecordFromParameter(ITypeSymbol parameterTypeSymbol, ICollection<Blueprint> blueprints)
    {
        if (blueprints.Any(x => x.Name == parameterTypeSymbol.Name))
            return;

        var recordBlueprint = new RecordBlueprint(parameterTypeSymbol.Name, FullNamespace, true);

        var parameters = parameterTypeSymbol
            .GetMembers()
            .OfType<IPropertySymbol>()
            //skip first equality property
            .Skip(1);

        foreach(var param in parameters)
        {
            recordBlueprint.AddParameter(GetPropertyType(param.Type), param.Name);

            GenerateParameters(param.Type, blueprints);
        }

        blueprints.Add(recordBlueprint);
    }

    private void GenerateEnumFromParameter(ITypeSymbol parameterTypeSymbol, ICollection<Blueprint> blueprints)
    {
        if (blueprints.Any(x => x.Name == parameterTypeSymbol.Name))
            return;

        var enumBlueprint = new EnumBlueprint(parameterTypeSymbol.Name, FullNamespace);

        var enumMembers = parameterTypeSymbol
            .GetMembers()
            .OfType<IFieldSymbol>();

        foreach (IFieldSymbol enumValue in enumMembers)
        {
            enumBlueprint.AddParameter(enumValue.ConstantValue?.ToString(), enumValue.Name);
        }

        blueprints.Add(enumBlueprint);
    }

    private string GetPropertyType(ITypeSymbol typeSymbol)
    {
        if (typeSymbol is IArrayTypeSymbol arrayTypeSymbol)
        {
            var elementType = GetPropertyType(arrayTypeSymbol.ElementType);
            return $"{elementType}{(arrayTypeSymbol.Rank == 1 ? "[]" : $"[{new string(',', arrayTypeSymbol.Rank - 1)}]")}";
        }

        if (typeSymbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType)
        {
            var typeName = Extensions.GetShortTypeName(namedTypeSymbol);
            return $"{typeName}<{string.Join(", ", namedTypeSymbol.TypeArguments.Select(GetPropertyType))}>";
        }

        return Extensions.GetShortTypeName(typeSymbol);
    }
}
