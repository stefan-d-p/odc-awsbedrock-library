using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A behavior assessment of a topic policy")]
public struct GuardrailTopicPolicyAssessment
{
    [OSStructureField(Description = "The topics in the assessment",
        IsMandatory = true)]
    public List<GuardrailTopic> Topics;
}