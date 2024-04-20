using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Mistral model request structure")]
public struct MistralTextRequest
{
    [OSStructureField(
        Description = "Input Text",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Prompt;
    
    [OSStructureField(
        Description = "Specify the maximum number of tokens to use in the generated response. The model truncates the response once the generated text exceeds this value. Defaults to 512",
        DataType = OSDataType.Integer,
        IsMandatory = false,
        DefaultValue = "512")]
    public int MaxTokens;
    
    [OSStructureField(
        Description = "Controls the randomness of predictions made by the model",
        IsMandatory = false,
        DefaultValue = "0.5")]
    public float Temperature;
}