namespace SourceGenerator;
public static class Constants
{
    public const string NamespacePrefix = "Generated.";
    public const string DtosFolderName = "Dtos";
    public const string DtosNamespacePart = $".{DtosFolderName}";
    public const string GlobalUsingsFileName = $"GlobalUsings{GeneratedFileExtension}";
    public const string GeneratedFileExtension = ".g.cs";
}
