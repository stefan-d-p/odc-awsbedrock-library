using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The content block to be evaluated by the guardrail")]
public struct GuardrailContentBlock
{
    [OSStructureField(Description = "Text within content block to be evaluated by the guardrail",
        IsMandatory = false)]
    public GuardrailTextBlock Text;
}