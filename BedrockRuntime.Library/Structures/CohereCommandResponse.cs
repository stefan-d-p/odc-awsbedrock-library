using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Response structure for Cohere Command Models")]
public struct CohereCommandResponse
{
    [OSStructureField(
        Description = "An identifier for the request",
        DataType = OSDataType.Text)]
    public string Id;

    [OSStructureField(
        Description = "The prompt from the input request",
        DataType = OSDataType.Text)]
    public string Prompt;
    
    [OSStructureField(
        Description = " A list of generated results along with the likelihoods for tokens requested")]
    public List<CohereCommandGeneration> Generations;
}

[OSStructure(
    Description = "Cohere Command Generation Item")]
public struct CohereCommandGeneration
{
    [OSStructureField(
        Description = "An identifier for the generation",
        DataType = OSDataType.Text)]
    public string Id;

    [OSStructureField(
        Description = "The generated text",
        DataType = OSDataType.Text)]
    public string Text;
}

[OSStructure(
    Description = "Cohere Embed Model Response")]
public struct CohereEmbedResponse
{
    [OSStructureField(
        Description = "An identifier for the response.",
        DataType = OSDataType.Text)]
    public string Id;

    [OSStructureField(
        Description = "The response type. This value is always embeddings_floats.",
        DataType = OSDataType.Text)]
    public string ResponseType;
    
    [OSStructureField(
        Description = "An array of embeddings, where each embedding is an array of floats with 1024 elements. The length of the embeddings array will be the same as the length of the original texts array.")]
    public List<Vector> Embeddings;
    
    [OSStructureField(
        Description = "An array containing the text entries for which embeddings were returned.")]
    public List<string> Texts;
}

[OSStructure(
    Description = "Vector struct. Representing a single vector embeddings array"
)]
public struct Vector
{
    [OSStructureField(
        Description = "Embedding array")]
    public List<float> Embedding;

    public Vector(List<float> embedding)
    {
        Embedding = embedding;
    }
    
}