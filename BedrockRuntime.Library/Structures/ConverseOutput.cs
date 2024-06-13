using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The output from a call")]
public struct ConverseOutput
{
    [OSStructureField(Description = "The message that the model generates",
        DataType = OSDataType.InferredFromDotNetType)]
    public Message Message;
}