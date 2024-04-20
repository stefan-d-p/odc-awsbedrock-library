using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class CohereCommandResponseDto
{
    [JsonPropertyName("id")]
    public string? Id;

    [JsonPropertyName("prompt")]
    public string? Prompt;
    
    [JsonPropertyName("generations")]
    public List<CohereCommandGenerationDto> Generations = null!;
}

public class CohereCommandGenerationDto
{
    [JsonPropertyName("id")]
    public string? Id;

    [JsonPropertyName("text")]
    public string? Text;
}