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

[OSStructure(
    Description = "Amazon Titan Embeddings G1 model response")]
public struct AmazonTitanEmbeddingsResponse
{
    [OSStructureField(
        Description = "An array that represents the embedding vector of the input you provided.")]
    public List<float> Embedding;
    
    [OSStructureField(
        Description = "The number of tokens in the input.",
        DataType = OSDataType.Integer)]
    public int InputTokenCount;
}