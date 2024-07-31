using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The output content produced by the guardrail")]
public struct GuardrailOutputContent
{
    [OSStructureField(Description = "The specific text for the output content produced by the guardrail",
        DataType = OSDataType.Text)]
    public string Text;
}