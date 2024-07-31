using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The word policy assessment")]
public struct GuardrailWordPolicyAssessment
{
    [OSStructureField(Description = "Custom words in the assessment",
        IsMandatory = true)]
    public List<GuardrailCustomWord> CustomWords;

    [OSStructureField(Description = "Managed word lists in the assessment",
        IsMandatory = true)]
    public List<GuardrailManagedWord> ManagedWordLists;
}