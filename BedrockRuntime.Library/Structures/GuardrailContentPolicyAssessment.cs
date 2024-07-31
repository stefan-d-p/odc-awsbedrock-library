using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;


[OSStructure(Description = "An assessment of a content policy for a guardrail.")]
public struct GuardrailContentPolicyAssessment
{
    [OSStructureField(Description = "The content policy filters",
        IsMandatory = true)]
    public List<GuardrailContentFilter> Filters { get; set; }

}