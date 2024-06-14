using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Configuration information for the tools that you pass to a model")]
public struct ToolConfiguration : IEquatable<ToolConfiguration>
{
    [OSStructureField(Description = "An array of tools that you want to pass to a model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public List<Tool> Tools = new List<Tool>();

    public ToolConfiguration()
    {
        
    }

    public static ToolConfiguration Default => new ToolConfiguration();

    public bool Equals(ToolConfiguration other)
    {
        return Tools.SequenceEqual(other.Tools);
    }

    public override bool Equals(object? obj)
    {
        return obj is ToolConfiguration other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Tools.GetHashCode();
    }
}