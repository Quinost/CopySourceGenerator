using Microsoft.CodeAnalysis;
using System.Linq;
using System.Text;

namespace SourceGenerator;

public static class Extensions
{
    public static string GetLastAssemblyName(string assemblyName) 
        => assemblyName.Split('.').Last();

    public static StringBuilder GenerateDefaultUsingsAndNamespaceCode(string namespaceName) 
        => new StringBuilder()
            .AppendLine("//auto-generated")
            .AppendLine("using System;")
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Collections.Concurrent;")
            .AppendLine("using System.Collections.Immutable;")
            .AppendLine("using System.Collections.ObjectModel;")
            .AppendLine()
            .AppendLine($"namespace {namespaceName};")
            .AppendLine();

    public static string GetShortTypeName(ITypeSymbol typeSymbol) 
        => typeSymbol.SpecialType is SpecialType.None ? typeSymbol.Name : typeSymbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
}