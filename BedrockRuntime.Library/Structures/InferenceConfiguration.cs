using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Base inference parameters to pass to a model in a call")]
public struct InferenceConfiguration
{
    [OSStructureField(Description = "The maximum number of tokens to allow in the generated response",
        DataType = OSDataType.Integer,
        IsMandatory = false)]
    public int? MaxTokens;
    
    [OSStructureField(Description = "A list of stop sequences",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<string>? StopSequences;
    
    [OSStructureField(Description = "The likelihood of the model selecting higher-probability options while generating a response",
        DataType = OSDataType.Decimal,
        IsMandatory = false)]
    public float? Temperature;
    
    [OSStructureField(Description = "The percentage of most-likely candidates that the model considers for the next token",
        DataType = OSDataType.Decimal,
        IsMandatory = false)]
    public float? TopP;
}