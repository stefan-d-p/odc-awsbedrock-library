using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Configuration information for the tools that you pass to a model")]
public struct ToolConfiguration
{
    [OSStructureField(Description = "An array of tools that you want to pass to a model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public List<Tool> Tools;
}