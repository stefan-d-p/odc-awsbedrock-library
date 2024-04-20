using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class AmazonTitanTextRequestDto
{
    [JsonPropertyName("inputText")] 
    public string? InputText;
    
    [JsonPropertyName("textGenerationConfig")]
    public AmazonTitanTextConfigurationDto Configuration = null!;
}

public class AmazonTitanTextConfigurationDto
{
   
    [JsonPropertyName("temperature")]
    public float Temperature = 1.0f;

    [JsonPropertyName("maxTokenCount")]
    public int MaxTokenCount = 512;
}