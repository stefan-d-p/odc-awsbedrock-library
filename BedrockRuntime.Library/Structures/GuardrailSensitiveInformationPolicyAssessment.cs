using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The assessment for aPersonally Identifiable Information (PII) policy.")]
public struct GuardrailSensitiveInformationPolicyAssessment
{
    [OSStructureField(Description = "The PII entities in the assessment",
        IsMandatory = true)]
    public List<GuardrailPiiEntityFilter> PiiEntities;

    [OSStructureField(Description = "The regex queries in the assessment",
        IsMandatory = true)]
    public List<GuardrailRegexFilter> Regexes;
}