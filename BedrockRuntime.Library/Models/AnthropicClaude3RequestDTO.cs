using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class AnthropicClaude3TextRequestDto
{
   
    [JsonPropertyName("anthropic_version")]
    public string? Version;
  
    [JsonPropertyName("max_tokens")]
    public int? MaxTokens;
    
    [JsonPropertyName("messages")]
    public List<AnthropicClaude3MessageDto>? Messages;
    
    [JsonPropertyName("system")]
    public string? System;
    
    [JsonPropertyName("temperature")]
    public float? Temperature;

}

public class AnthropicClaude3MessageDto
{
 
    [JsonPropertyName("role")]
    public string? Role;
    
  
    [JsonPropertyName("content")]
    public List<AnthropicClaude3ContentRequestItemDto>? Content;
}

public class AnthropicClaude3ContentRequestItemDto
{
    [JsonPropertyName("type")]
    public string? Type;
    
    [JsonPropertyName("text")]
    public string? Text;
    
    [JsonPropertyName("source")]
    public AnthropicClaude3SourceRequestDto? Source;
}

public class AnthropicClaude3SourceRequestDto
{

    [JsonPropertyName("type")]
    public string? Type;
   
    [JsonPropertyName("media_type")]
    public string? MediaType;
    
    [JsonPropertyName("data")]
    public string? Data;
}