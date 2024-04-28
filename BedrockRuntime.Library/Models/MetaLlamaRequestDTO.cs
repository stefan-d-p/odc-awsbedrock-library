using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class MetaLlamaTextRequestDto
{
    [JsonPropertyName("prompt")]
    public string Prompt;

    [JsonPropertyName("temperature")]
    public float Temperature;
    
    [JsonPropertyName("top_p")]
    public float TopP;

    [JsonPropertyName("max_gen_len")]
    public int MaxTokens;

}