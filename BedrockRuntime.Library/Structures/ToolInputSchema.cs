using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The schema for the tool")]
public struct ToolInputSchema
{
    [OSStructureField(Description = "The JSON schema for the tool",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Json;
}