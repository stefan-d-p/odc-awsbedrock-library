using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The tool result content block")]
public struct ToolResultContentBlock
{
    [OSStructureField(Description = "A tool result that is an image",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public ImageBlock Image = ImageBlock.Default;
    
    [OSStructureField(Description = "A tool result that is JSON format data",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Json = String.Empty;
    
    [OSStructureField(Description = "A tool result that is text",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Text = String.Empty;

    public ToolResultContentBlock()
    {
        
    }

    public static ToolResultContentBlock Default => new ToolResultContentBlock();
}