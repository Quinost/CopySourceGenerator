using System.Linq;

namespace SourceGenerator.Blueprints;
public sealed class RecordBlueprint(string RecordName, string Namespace) 
    : Blueprint(RecordName, Namespace)
{
    public override string ToFullCode()
    {
        var sb = Extensions.GenerateDefaultUsingsAndNamespaceCode(Namespace);

        sb.AppendLine($"public record {Name} (");

        if (parameters.Count != 0)
        {
            var last = parameters.Last();
            foreach (var param in parameters)
            {
                sb.AppendLine($"    {param.TypeOrValue} {param.Name}{(param != last ? ",": "")}");
            }
        }

        sb.AppendLine(");");

        return sb.ToString();
    }
}
