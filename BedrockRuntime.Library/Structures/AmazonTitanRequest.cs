using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Amazon Titan model request structure")]
public struct AmazonTitanTextRequest
{

    [OSStructureField(
        Description = "Input Text",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string InputText;

    [OSStructureField(
        Description = "Titan Text Generation Configuration",
        IsMandatory = false)]
    public AmazonTitanTextConfiguration Configuration;

}

[OSStructure(
    Description = "Titan Text Generation Configuration")]
public struct AmazonTitanTextConfiguration
{
    public AmazonTitanTextConfiguration()
    {
    }

    [OSStructureField(
        Description = "Use a lower value to decrease randomness in the response.",
        IsMandatory = false,
        DefaultValue = "1.0")]
    public float Temperature = 1.0f;

    [OSStructureField(
        Description = "Maximum number of tokens to generate",
        DataType = OSDataType.Integer,
        IsMandatory = false,
        DefaultValue = "512")]
    public int MaxTokenCount = 512;
}