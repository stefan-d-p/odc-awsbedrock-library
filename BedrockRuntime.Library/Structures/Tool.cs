using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Information about a tool that you can use with the Converse API")]
public struct Tool
{
    [OSStructureField(Description = "The specification for the tools",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public ToolSpecification ToolSpec = ToolSpecification.Default;

    public Tool()
    {
        
    }

    public static Tool Default => new Tool();
}