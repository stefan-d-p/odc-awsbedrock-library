using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class AmazonTitanTextResponseDto
{
    [JsonPropertyName("inputTextTokenCount")]
    public int InputTextTokenCount;

    [JsonPropertyName("results")]
    public List<AmazonTitanTextResultItemDto>? Results = null;
}

public class AmazonTitanTextResultItemDto
{
    [JsonPropertyName("tokenCount")]
    public int? TokenCount;
    
    [JsonPropertyName("outputText")]
    public string? OutputText;
    
    [JsonPropertyName("completionReason")]
    public string? CompletionReason;
}

public class AmazonTitanEmbeddingsResponseDto
{
    [JsonPropertyName("embedding")]
    public List<float> Embedding;
    
    [JsonPropertyName("inputTextTokenCount")]
    public int? InputTokenCount;
}