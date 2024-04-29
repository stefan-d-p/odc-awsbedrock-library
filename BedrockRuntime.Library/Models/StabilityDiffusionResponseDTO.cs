using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class StabilityDiffusionTextToImageResponseDto
{
    [JsonPropertyName("result")]
    public string Result;
    
    [JsonPropertyName("artifacts")]
    public List<StabilityDiffusionArtifactDto> Artifacts;
}

public class StabilityDiffusionArtifactDto
{
    [JsonPropertyName("seed")]
    public long Seed;
    
    [JsonPropertyName("base64")]
    public string Image;
    
    [JsonPropertyName("finished_reason")]
    public string FinishedReason;
}