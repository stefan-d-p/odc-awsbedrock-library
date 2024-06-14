using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The specification for the tool")]
public struct ToolSpecification
{
    [OSStructureField(Description = "The description for the tool",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Description = String.Empty;
    
    [OSStructureField(Description = "The input schema for the tool in JSON format",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public ToolInputSchema InputSchema = ToolInputSchema.Default;
    
    [OSStructureField(Description = "The name for the tool",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Name = String.Empty;

    public ToolSpecification()
    {
        
    }

    public static ToolSpecification Default => new ToolSpecification();
}