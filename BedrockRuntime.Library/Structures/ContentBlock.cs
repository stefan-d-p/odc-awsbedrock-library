using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A block of content for a message")]
public struct ContentBlock
{
    [OSStructureField(Description = "Image to include in the message",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public ImageBlock? Image;
    
    [OSStructureField(Description = "Text to include in the message",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? Text;
    
    [OSStructureField(Description = "The result for a tool request that a model makes.",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public ToolResultBlock? ToolResult;

    [OSStructureField(Description = "Information about a tool use request from a model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public ToolUseBlock? ToolUse;
}