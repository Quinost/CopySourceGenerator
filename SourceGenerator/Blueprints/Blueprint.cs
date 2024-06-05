using System;
using System.Collections.Generic;

namespace SourceGenerator.Blueprints;
public abstract class Blueprint(string Name, string Namespace, bool IsDto)
{
    public string Name = Name;
    public string FileName = $"{Name}{Constants.GeneratedFileExtension}";
    public bool IsDto = IsDto;
    protected string Namespace = Namespace;
    protected bool AddDtoUsing = false;

    protected readonly ICollection<(string TypeOrValue, string Name)> parameters = [];

    public virtual void AddParameter(string typeOrValue, string name)
    {
        parameters.Add(new(typeOrValue, name));
    }

    public virtual void SetAddDtoUsing()
    {
        if (!IsDto)
            AddDtoUsing = true;
    }

    public abstract string ToFullCode();
}
