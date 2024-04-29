using System.Text.Json.Serialization;

namespace Without.Systems.BedrockRuntime.Models;

public class StabilityDiffusionTextToImageRequestDto
{
    [JsonPropertyName("text_prompts")]
    public List<StabilityDiffusionTextPromptDto> TextPrompts;
    
    [JsonPropertyName("height")]
    public int Height;
    
    [JsonPropertyName("width")]
    public int Width;
    
    [JsonPropertyName("cfg_scale")]
    public float CfgScale;
    
    [JsonPropertyName("clip_guidance_preset")]
    public string ClipGuidancePreset;
    
    [JsonPropertyName("steps")]
    public int Steps;
    
}

public class StabilityDiffusionTextPromptDto
{
    [JsonPropertyName("text")]
    public string Text;
    
    [JsonPropertyName("weight")]
    public float Weight;
    
}