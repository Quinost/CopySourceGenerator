namespace SourceGenerator.Blueprints;
public sealed class EnumBlueprint(string EnumName, string NamespaceWithPrefix, string Version) 
    : Blueprint(EnumName, NamespaceWithPrefix, Version)
{
    public override string ToFullCode()
    {
        var sb = Extensions.GenerateDefaultUsingsAndNamespaceCode(Version, NamespaceWithPrefix);

        sb.AppendLine($"public enum {Name}");
        sb.AppendLine("{");

        foreach (var param in parameters)
        {
            sb.AppendLine($"    {param.Name} = {param.Type},");
        }

        sb.AppendLine("}");

        return sb.ToString();
    }
}
