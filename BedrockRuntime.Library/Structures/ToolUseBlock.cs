using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A tool use content block")]
public struct ToolUseBlock
{
    [OSStructureField(Description = "The input to pass to the tool",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Input;

    [OSStructureField(Description = "The name of the tool that the model wants to use",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Name;
    
    [OSStructureField(Description = "The ID for the tool request",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ToolUseId;
}