using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class MistralTextRequestDto
{
    [JsonPropertyName("prompt")]
    public string? Prompt;

    [JsonPropertyName("max_tokens")] public int MaxTokens = 512;

    [JsonPropertyName("temperature")] public float Temperature = 0.5f;
}