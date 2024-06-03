using System;
using System.Collections.Generic;

namespace SourceGenerator.Blueprints;
public abstract class Blueprint(string Name, string Namespace)
{
    public string Name = Name;
    public string Namespace = Namespace;
    public string FileName = $"{Name}.g.cs";

    protected readonly ICollection<(string TypeOrValue, string Name)> parameters = [];

    public virtual void AddParameter(string typeOrValue, string name)
    {
        parameters.Add(new(typeOrValue, name));
    }

    public abstract string ToFullCode();
}
