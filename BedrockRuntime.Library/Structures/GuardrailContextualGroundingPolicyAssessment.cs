using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The policy assessment details for the guardrails contextual grounding filter")]
public struct GuardrailContextualGroundingPolicyAssessment
{
    [OSStructureField(Description = "The filter details for the guardrails contextual grounding filter")]
    public List<GuardrailContextualGroundingFilter> Filters;
}