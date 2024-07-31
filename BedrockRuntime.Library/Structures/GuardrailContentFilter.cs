using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The content filter for a guardrail")]
public struct GuardrailContentFilter
{
    [OSStructureField(Description = "The guardrail action",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Action;
    
    [OSStructureField(Description = "The guardrail confidence",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Confidence;
    
    [OSStructureField(Description = "The guardrail type",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Type;
}