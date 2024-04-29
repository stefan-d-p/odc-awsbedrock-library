using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Stability Diffusion 1.0 Response")]
public struct StabilityDiffusionTextToImageResponse
{
    [OSStructureField(
        Description = "The result of the operation. If successful, the response is success",
        DataType = OSDataType.Text)]
    public string Result;

    [OSStructureField(
        Description = "An array of images, one for each requested image")]
    public List<StabilityDiffusionArtifact> Artifacts;
}

[OSStructure(
    Description = "Stability Diffusion Artifact Item")]
public struct StabilityDiffusionArtifact
{
    [OSStructureField(
        Description = "The value of the seed used to generate the image",
        DataType = OSDataType.LongInteger)]
    public long Seed;
    
    [OSStructureField(
        Description = "The generated image",
        DataType = OSDataType.BinaryData)]
    public byte[] Image;

    [OSStructureField(
        Description =
            "The result of the image generation process. Valid values are:\n\nSUCCESS – The image generation process succeeded.\n\nERROR – An error occured.\n\nCONTENT_FILTERED – The content filter filtered the image and the image might be blurred.",
        DataType = OSDataType.Text)]
    public string FinishedReason;
}