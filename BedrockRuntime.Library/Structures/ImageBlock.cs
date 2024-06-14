using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Image content for a message")]
public struct ImageBlock
{
    [OSStructureField(Description = "The format of the image",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Format = String.Empty;

    [OSStructureField(Description = "The source for the image",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public ImageSource Source = ImageSource.Default;

    public ImageBlock()
    {
        
    }

    public static ImageBlock Default => new ImageBlock();
}