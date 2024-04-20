using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Response structure for Amazon Titan Text Models")]
public struct AmazonTitanTextResponse
{
    [OSStructureField(
        Description = "Token count of input text",
        DataType = OSDataType.Integer)]
    public int InputTextTokenCount;

    [OSStructureField(
        Description = "Array of generated results",
        DataType = OSDataType.InferredFromDotNetType)]
    public List<AmazonTitanTextResultItem> Results;

}

[OSStructure(
    Description = "Amazon Titan Text Model Result Item")]
public struct AmazonTitanTextResultItem
{
    [OSStructureField(
        Description = "Token count of generated text",
        DataType = OSDataType.Integer)]
    public int TokenCount;
    
    [OSStructureField(
        Description = "Generated text",
        DataType = OSDataType.Text)]
    public string OutputText;
    
    [OSStructureField(
        Description = "Reason of completion",
        DataType = OSDataType.Text)]
    public string CompletionReason;
}