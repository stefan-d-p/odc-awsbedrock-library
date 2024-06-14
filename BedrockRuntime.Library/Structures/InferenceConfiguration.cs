using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Base inference parameters to pass to a model in a call")]
public struct InferenceConfiguration : IEquatable<InferenceConfiguration>
{
    [OSStructureField(Description = "The maximum number of tokens to allow in the generated response",
        DataType = OSDataType.Integer,
        IsMandatory = false)]
    public int MaxTokens = 0;
    
    [OSStructureField(Description = "A list of stop sequences",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<string> StopSequences = new List<string>();
    
    [OSStructureField(Description = "The likelihood of the model selecting higher-probability options while generating a response",
        DataType = OSDataType.Decimal,
        IsMandatory = false)]
    public float Temperature = 0f;

    [OSStructureField(
        Description = "The percentage of most-likely candidates that the model considers for the next token",
        DataType = OSDataType.Decimal,
        IsMandatory = false)]
    public float TopP = 0f;

    public InferenceConfiguration()
    {
        
    }

    public static InferenceConfiguration Default => new InferenceConfiguration();

    public bool Equals(InferenceConfiguration other)
    {
        bool bMaxTokens = MaxTokens == other.MaxTokens;
        bool bStopSequeneces = StopSequences.SequenceEqual(other.StopSequences);
        bool bTemperature = Temperature.Equals(other.Temperature);
        bool bTopP = TopP.Equals(other.TopP);
        return bMaxTokens && bStopSequeneces && bTemperature && bTopP;
    }

    public override bool Equals(object? obj)
    {
        return obj is InferenceConfiguration other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MaxTokens, StopSequences, Temperature, TopP);
    }
}