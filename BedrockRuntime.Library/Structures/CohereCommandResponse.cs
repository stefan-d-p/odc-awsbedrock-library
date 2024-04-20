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