namespace SourceGenerator.Blueprints;
public sealed class EnumBlueprint(string EnumName, string Namespace) 
    : Blueprint(EnumName, Namespace)
{
    public override string ToFullCode()
    {
        var sb = Extensions.GenerateDefaultUsingsAndNamespaceCode(Namespace);

        sb.AppendLine($"public enum {Name}");
        sb.AppendLine("{");

        foreach (var param in parameters)
        {
            sb.AppendLine($"    {param.Name} = {param.TypeOrValue},");
        }

        sb.AppendLine("}");

        return sb.ToString();
    }
}
