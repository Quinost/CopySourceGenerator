using System.Linq;

namespace SourceGenerator.Blueprints;
public sealed class RecordBlueprint(string RecordName, string NamespaceWithPrefix, string Version) 
    : Blueprint(RecordName, NamespaceWithPrefix, Version)
{
    public override string ToFullCode()
    {
        var sb = Extensions.GenerateDefaultUsingsAndNamespaceCode(Version, NamespaceWithPrefix);

        sb.AppendLine($"public record {Name} (");

        if (parameters.Count != 0)
        {
            var last = parameters.Last();
            foreach (var param in parameters)
            {
                sb.AppendLine($"    {param.Type} {param.Name}{(param != last ? ",": "")}");
            }
        }

        sb.AppendLine(");");

        return sb.ToString();
    }
}
