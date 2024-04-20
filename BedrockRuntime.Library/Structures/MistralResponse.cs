using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Mistral text model response")]
public struct MistralTextResponse
{
    public List<MistralTextOutputItem> Outputs;
}

[OSStructure(
    Description = "Mistral text model output item structure")]
public struct MistralTextOutputItem
{
    [OSStructureField(
        Description = "The text that the model generated",
        DataType = OSDataType.Text)]
    public string Text;

    [OSStructureField(
        Description = "The reason why the response stopped generating text.",
        DataType = OSDataType.Text)]
    public string StopReason;
}