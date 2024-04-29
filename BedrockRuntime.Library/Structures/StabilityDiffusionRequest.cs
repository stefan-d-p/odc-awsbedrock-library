using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Stability Diffusion 1.0 Request")]
public struct StabilityDiffusionTextToImageRequest
{
    [OSStructureField(
        Description = "Array of text prompts",
        IsMandatory = true)]
    public List<StabilityDiffusionTextPrompt> TextPrompts;
    
    [OSStructureField(
        Description = "Height of the image to generate, in pixels, in an increment divisible by 64.\n\nThe value must be one of 1024x1024, 1152x896, 1216x832, 1344x768, 1536x640, 640x1536, 768x1344, 832x1216, 896x1152",
        IsMandatory = false,
        DataType = OSDataType.Integer,
        DefaultValue = "1024")]
    public int Height;
    
    [OSStructureField(
        Description = "Width of the image to generate, in pixels, in an increment divisible by 64.\n\nThe value must be one of 1024x1024, 1152x896, 1216x832, 1344x768, 1536x640, 640x1536, 768x1344, 832x1216, 896x1152",
        IsMandatory = false,
        DataType = OSDataType.Integer,
        DefaultValue = "1024")]
    public int Width;

    [OSStructureField(
        Description =
            "Determines how much the final image portrays the prompt. Use a lower number to increase randomness in the generation.",
        IsMandatory = false,
        DefaultValue = "7.0")]
    public float CfgScale;

    [OSStructureField(
        Description = "Enum: FAST_BLUE, FAST_GREEN, NONE, SIMPLE SLOW, SLOWER, SLOWEST",
        DataType = OSDataType.Text,
        IsMandatory = false,
        DefaultValue = "NONE")]
    public string ClipGuidancePreset;
    
    [OSStructureField(
        Description = " Generation step determines how many times the image is sampled. More steps can result in a more accurate result.",
        DataType = OSDataType.Integer,
        IsMandatory = false,
        DefaultValue = "30")]
    public int Steps;
    
}

[OSStructure(
    Description = "Single Text prompt element")]
public struct StabilityDiffusionTextPrompt
{
    [OSStructureField(
        Description = "Text prompt",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Text;
    
    [OSStructureField(
        Description = "The weight that the model should apply to the prompt. A value that is less than zero declares a negative prompt. Use a negative prompt to tell the model to avoid certain concepts",
        IsMandatory = false,
        DefaultValue = "1.0")]
    public float Weight;
    
    
}