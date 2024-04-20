using System.Text.Json.Serialization;
using Without.Systems.BedrockRuntime.Structures;

namespace Without.Systems.BedrockRuntime.Models;

public class AnthropicClaude3TextResponseDto
{
  
    [JsonPropertyName("id")]
    public string? Id;

    [JsonPropertyName("model")]
    public string? Model;

    [JsonPropertyName("type")]
    public string? Type;
    
    [JsonPropertyName("role")]
    public string? Role;
    
    [JsonPropertyName("stop_reason")]
    public string? StopReason;
    
    [JsonPropertyName("stop_sequence")]
    public string? StopSequence;

    [JsonPropertyName("content")]
    public List<AnthropicClaude3ContentResponseItemDto>? Content = null;

    [JsonPropertyName("usage")]
    public AnthropicClaude3UsageDto Usage = null!;

}

public class AnthropicClaude3ContentResponseItemDto
{
   
    [JsonPropertyName("type")]
    public string? Type;
    
    [JsonPropertyName("text")]
    public string? Text;
}

public class AnthropicClaude3UsageDto
{
   
    [JsonPropertyName("input_tokens")]
    public int InputTokens;

    [JsonPropertyName("output_tokens")]
    public int OutputTokens;
}
