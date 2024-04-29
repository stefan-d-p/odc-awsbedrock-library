using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class CohereCommandRequestDto
{
    [JsonPropertyName("prompt")]
    public string? Prompt;

    [JsonPropertyName("max_tokens")]
    public int MaxTokens = 400;

    [JsonPropertyName("temperature")]
    public float Temperature = 0.9f;

    [JsonPropertyName("p")]
    public float TopP = 0.01f;

    [JsonPropertyName("k")]
    public int TopK = 0;
}

public struct CohereEmbedRequestDto
{
    [JsonPropertyName("texts")]
    public List<string> Texts;
   
    [JsonPropertyName("input_type")]
    public string InputType;
    
    [JsonPropertyName("truncate")]
    public string Truncate;
}