using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A tool result block that contains the results for a tool request that the model previously made")]
public struct ToolResultBlock
{
    [OSStructureField(Description = "The content for tool result content block",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<ToolResultContentBlock> Content;
    
    [OSStructureField(Description = "The tool result status",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Status;
}