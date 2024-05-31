﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SourceGenerator.Blueprints;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SourceGenerator;

[Generator]
public class CopyGenerator : IIncrementalGenerator
{
    private const string NamespacePrefix = "Generated.";
    private string DirectoryPath = default;
    private string FullNamespace = default;
    private string Version = default;

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        Version = Guid.NewGuid().ToString();
        context.RegisterSourceOutput(context.AnalyzerConfigOptionsProvider, (source, options) =>
        {
            //Get generated file source code path to find autogenerated library
            //TODO: Fix it
            if (options.GlobalOptions.TryGetValue("build_property.projectdir", out var projectPath))
                DirectoryPath = projectPath + "#" + "\\CopySourceGenerator";
        });

        context.RegisterSourceOutput(context.CompilationProvider, (sourceContext, compilation) =>
        {
            // Get all record declarations in the compilation
            var records = compilation.SyntaxTrees
                .SelectMany(tree => tree.GetRoot().DescendantNodes())
                .OfType<RecordDeclarationSyntax>()
                .Where(x => x.Identifier.Text == "BasicTypesModel");

            ICollection<Blueprint> Blueprints = [];

            FullNamespace = NamespacePrefix + Extensions.GetLastAssemblyName(compilation.AssemblyName);

            foreach(var record in records)
            {
                Debugger.Launch();
                var recordBlueprint = new RecordBlueprint(record.Identifier.Text, FullNamespace, Version);

                var semanticModel = compilation.GetSemanticModel(record.SyntaxTree);
                GetParameters(recordBlueprint, record, Blueprints, semanticModel);

                Blueprints.Add(recordBlueprint);
            }

            foreach (var toSave in Blueprints)
            {
                SaveFile(toSave);
            }
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

        var recordBlueprint = new RecordBlueprint(parameterTypeSymbol.Name, FullNamespace, Version);

        var parameters = parameterTypeSymbol.GetMembers().OfType<IPropertySymbol>().Skip(1).ToList();

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

        var enumBlueprint = new EnumBlueprint(parameterTypeSymbol.Name, FullNamespace, Version);

        var enumMembers = parameterTypeSymbol.GetMembers().OfType<IFieldSymbol>();

        foreach (IFieldSymbol enumValue in parameterTypeSymbol.GetMembers().OfType<IFieldSymbol>())
        {
            enumBlueprint.AddParameter(enumValue.ConstantValue?.ToString(), enumValue.Name);
        }

        blueprints.Add(enumBlueprint);
    }

    private string GetPropertyType(ITypeSymbol typeSymbol)
    {
        bool isNullable = typeSymbol.IsNullable();

        if (typeSymbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType)
        {
            var typeName = namedTypeSymbol.Name;
            var typeArguments = string.Join(", ", namedTypeSymbol.TypeArguments.Select(GetPropertyType));
            var fullTypeName = $"{typeName}<{typeArguments}>";
            return isNullable ? $"{fullTypeName}?" : fullTypeName;
        }

        var regularTypeName = typeSymbol.Name;
        return isNullable ? $"{regularTypeName}?" : regularTypeName;
    }

    private void SaveFile(Blueprint blueprint)
    {
        var path = Path.Combine(DirectoryPath, $"src\\AutoGenerated\\{blueprint.NamespaceLast}");

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var filePath = Path.Combine(path, $"{blueprint.Name}.generated.cs");
        File.WriteAllText(filePath, blueprint.ToFullCode());
    }
}
