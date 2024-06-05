using System.Text;

namespace SourceGenerator.Blueprints;
public sealed class EnumBlueprint(string EnumName, string Namespace) 
    : Blueprint(EnumName, Namespace, true)
{
    public override string ToFullCode()
    {
        var sb = Extensions.GenerateDefaultUsingsAndNamespaceCode(Namespace, AddDtoUsing, IsDto)
            .AppendLine($"public enum {Name}")
            .AppendLine("{");

        foreach (var param in parameters)
        {
            sb.AppendLine($"    {param.Name} = {param.TypeOrValue},");
        }

        sb.AppendLine("}");

        return sb.ToString();
    }
}
