using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class MetaLlamaTextResponseDto
{
    [JsonPropertyName("generation")]
    public string text;
    
    [JsonPropertyName("prompt_token_count")]
    public int PromptTokenCount;

    [JsonPropertyName("generation_token_count")]
    public int GenerationTokenCount;

    [JsonPropertyName("stop_reason")]
    public string StopReason;

}