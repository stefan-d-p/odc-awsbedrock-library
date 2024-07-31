using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The text block to be evaluated by the guardrail.")]
public struct GuardrailTextBlock
{
    [OSStructureField(Description = "The qualifiers describing the text block",
        IsMandatory = false)]
    public List<string> Qualifiers { get; set; }

    [OSStructureField(Description = "The input text details to be evaluated by the guardrail",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Text { get; set; }
}