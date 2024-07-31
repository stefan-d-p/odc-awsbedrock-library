using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Apply Guardrail Response Structure")]
public struct ApplyGuardrailResponse
{
    [OSStructureField(Description = "The action taken in the response from the guardrail",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Action;

    [OSStructureField(Description = "The assessment details in the response from the guardrail")]
    public List<GuardrailAssessment> Assessments;

    [OSStructureField(Description = "The output details in the response from the guardrail")]
    public List<GuardrailOutputContent> Outputs;

    [OSStructureField(Description = "The usage details in the response from the guardrail")]
    public GuardrailUsage Usage;
}