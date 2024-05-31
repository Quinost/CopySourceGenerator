using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGenerator;
public static class Extensions
{
    public static string GetLastAssemblyName(string assemblyName) 
        => assemblyName.Split('.').Last();

    public static bool IsNullable(this ITypeSymbol type)
        => type.SpecialType == SpecialType.System_Nullable_T;

    public static StringBuilder GenerateDefaultUsingsAndNamespaceCode(string version, string namespaceName) 
        => new StringBuilder()
            .AppendLine($"//{version}")
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