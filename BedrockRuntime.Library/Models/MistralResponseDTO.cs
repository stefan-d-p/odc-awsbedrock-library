using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class MistralTextResponseDto
{
    [JsonPropertyName("outputs")]
    public List<MistralTextOutputItemDto> Outputs = null!;
}

public class MistralTextOutputItemDto
{
    [JsonPropertyName("text")]
    public string? Text;

    [JsonPropertyName("stop_reason")]
    public string? StopReason;
}