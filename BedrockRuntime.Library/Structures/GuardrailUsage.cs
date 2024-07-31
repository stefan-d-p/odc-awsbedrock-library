using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The details on the use of the guardrail")]
public struct GuardrailUsage
{
    [OSStructureField(Description = "The content policy units processed by the guardrail",
        DataType = OSDataType.Integer)]
    public int ContentPolicyUnits;
    
    [OSStructureField(Description = "The contextual grounding policy units processed by the guardrail",
        DataType = OSDataType.Integer)]
    public int ContextualGroundingPolicyUnits;

    [OSStructureField(Description = "The sensitive information policy free units processed by the guardrail",
        DataType = OSDataType.Integer)]
    public int SensitiveInformationPolicyFreeUnits;

    [OSStructureField(Description = "The sensitive information policy units processed by the guardrail",
        DataType = OSDataType.Integer)]
    public int SensitiveInformationPolicyUnits;

    [OSStructureField(Description = "The topic policy units processed by the guardrail",
        DataType = OSDataType.Integer)]
    public int TopicPolicyUnits;

    [OSStructureField(Description = "The word policy units processed by the guardrail",
        DataType = OSDataType.Integer)]
    public int WordPolicyUnits;
}