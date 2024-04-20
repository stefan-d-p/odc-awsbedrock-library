using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Cohere Command Model Request")]
public struct CohereCommandRequest
{
    [OSStructureField(
        Description = "Input Text",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Prompt;
    
    [OSStructureField(
        Description = "Specify the maximum number of tokens to use in the generated response.",
        DataType = OSDataType.Integer,
        IsMandatory = false,
        DefaultValue = "400")]
    public int MaxTokens;
    
    [OSStructureField(
        Description = "Use a lower value to decrease randomness in the response. Default 0.9",
        IsMandatory = false,
        DefaultValue = "0.9")]
    public float Temperature;
    
    [OSStructureField(
        Description = "Use a lower value to ignore less probable options. Set to 0 or 1.0 to disable. If both TopP and TopK are enabled, TopP acts after TopK.",
        IsMandatory = false,
        DefaultValue = "0.01")]
    public float TopP;
    
    [OSStructureField(
        Description = "Specify the number of token choices the model uses to generate the next token. If both TopP and TopK are enabled, TopP acts after TopK.",
        IsMandatory = false,
        DefaultValue = "0")]
    public int TopK;
}