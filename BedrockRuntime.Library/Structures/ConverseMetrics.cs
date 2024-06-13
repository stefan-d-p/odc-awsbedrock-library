using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Metrics for a call")]
public struct ConverseMetrics
{
    [OSStructureField(Description = "The latency of the call to in milliseconds",
        DataType = OSDataType.LongInteger)]
    public long? LatencyMs;
    
    
}