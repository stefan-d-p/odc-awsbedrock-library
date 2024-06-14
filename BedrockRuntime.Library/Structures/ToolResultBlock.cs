using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A tool result block that contains the results for a tool request that the model previously made")]
public struct ToolResultBlock : IEquatable<ToolResultBlock>
{
    [OSStructureField(Description = "The content for tool result content block",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<ToolResultContentBlock> Content = new List<ToolResultContentBlock>();
    
    [OSStructureField(Description = "The tool result status",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Status = String.Empty;

    public ToolResultBlock()
    {
        
    }

    public static ToolResultBlock Default => new ToolResultBlock();

    public bool Equals(ToolResultBlock other)
    {
        return Content.SequenceEqual(other.Content) && Status == other.Status;
    }

    public override bool Equals(object? obj)
    {
        return obj is ToolResultBlock other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Content, Status);
    }
}