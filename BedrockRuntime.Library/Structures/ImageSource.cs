using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The source for an image")]
public struct ImageSource
{
    [OSStructureField(Description = "Image Binary Data",
        DataType = OSDataType.BinaryData,
        IsMandatory = true)]
    public byte[] Data;
}