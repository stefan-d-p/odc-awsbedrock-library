using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A behavior assessment of the guardrail policies used in a call to the Converse API")]
public struct GuardrailAssessment
{
    [OSStructureField(Description = "The content policy")]
    public GuardrailContentPolicyAssessment ContentPolicy;

    [OSStructureField(Description = "The contextual grounding policy used for the guardrail assessment")]
    public GuardrailContextualGroundingPolicyAssessment ContextualGroundingPolicy;

    [OSStructureField(Description = "The sensitive information policy")]
    public GuardrailSensitiveInformationPolicyAssessment SensitiveInformationPolicy;

    [OSStructureField(Description = "The topic policy")]
    public GuardrailTopicPolicyAssessment TopicPolicy;

    [OSStructureField(Description = "The word policy")]
    public GuardrailWordPolicyAssessment WordPolicy;
}