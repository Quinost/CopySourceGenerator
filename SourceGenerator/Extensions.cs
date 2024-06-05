using Microsoft.CodeAnalysis;
using System.Linq;
using System.Text;

namespace SourceGenerator;

public static class Extensions
{
    public static string GetLastAssemblyName(string assemblyName)
        => assemblyName.Split('.').Last();

    public static StringBuilder GenerateDefaultUsingsAndNamespaceCode(string namespaceName, bool addDtoUsing, bool isDto)
    {
        var sb = new StringBuilder()
                .AppendLine("//auto-generated");

        if (addDtoUsing)
            sb.AppendLine($"using {namespaceName}{Constants.DtosNamespacePart};");

        sb.AppendLine()
            .AppendLine($"namespace {namespaceName}{(isDto ? Constants.DtosNamespacePart : "")};")
            .AppendLine();

        return sb;
    }

    public static string GetShortTypeName(ITypeSymbol typeSymbol)
        => typeSymbol.SpecialType is SpecialType.None ? typeSymbol.Name : typeSymbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
}