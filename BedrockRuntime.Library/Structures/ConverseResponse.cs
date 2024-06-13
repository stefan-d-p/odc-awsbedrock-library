using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "This is the response object from the Converse operation")]
public struct ConverseResponse
{
    [OSStructureField(Description = "Additional fields in the response that are unique to the model",
        DataType = OSDataType.Text)]
    public string? AdditionalModelResponseFields;

    [OSStructureField(Description = " Metrics for the call",
        DataType = OSDataType.InferredFromDotNetType)]
    public ConverseMetrics Metrics;
    
    [OSStructureField(Description = "The result from the call",
        DataType = OSDataType.InferredFromDotNetType)]
    public ConverseOutput? Output;
    
    [OSStructureField(Description = "The reason why the model stopped generating output",
        DataType = OSDataType.Text)]
    public string? StopReason;

    [OSStructureField(Description = "The total number of tokens used in the call to Converse",
        DataType = OSDataType.InferredFromDotNetType)]
    public TokenUsage Usage;
}