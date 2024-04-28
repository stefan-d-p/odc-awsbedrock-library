using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Meta Llama model request structure")]
public struct MetaLlamaTextRequest
{

    [OSStructureField(
        Description = "Prompt",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Prompt;

    [OSStructureField(
        Description = "Use a lower value to decrease randomness in the response. Default 0.5",
        DefaultValue = "0.5",
        IsMandatory = false)]
    public float Temperature;
    
    [OSStructureField(
        Description = "Use a lower value to ignore less probable options. Set to 0 or 1.0 to disable.",
        DefaultValue = "0.9",
        IsMandatory = false)]
    public float TopP;

    [OSStructureField(
        Description = "Specify the maximum number of tokens to use in the generated response.",
        DataType = OSDataType.Integer,
        DefaultValue = "512",
        IsMandatory = false)]
    public int MaxTokens;

}
