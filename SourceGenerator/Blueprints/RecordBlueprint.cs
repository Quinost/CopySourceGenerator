using System.Linq;
using System.Text;

namespace SourceGenerator.Blueprints;
public sealed class RecordBlueprint(string RecordName, string Namespace, bool IsDto = false) 
    : Blueprint(RecordName, Namespace, IsDto)
{
    public override string ToFullCode()
    {
        var sb = Extensions.GenerateDefaultUsingsAndNamespaceCode(Namespace, AddDtoUsing, IsDto)
            .AppendLine($"public record {Name} (");

        if (parameters.Count != 0)
        {
            var last = parameters.Last();
            foreach (var param in parameters)
            {
                sb.AppendLine($"    {param.TypeOrValue} {param.Name}{(param != last ? "," : "")}");
            }
        }

        sb.AppendLine(");");

        return sb.ToString();
    }
}
