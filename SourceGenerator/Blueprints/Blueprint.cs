using System.Collections.Generic;
using System.Linq;

namespace SourceGenerator.Blueprints;
public abstract class Blueprint(string Name, string NamespaceWithPrefix, string Version)
{
    public string Name = Name;
    public string Version = Version;
    public string NamespaceWithPrefix = NamespaceWithPrefix;
    public string NamespaceLast = NamespaceWithPrefix.Split('.').Last();

    protected readonly ICollection<Parameter> parameters = [];

    public virtual void AddParameter(string type, string name)
    {
        parameters.Add(new(type, name));
    }

    public abstract string ToFullCode();
}
