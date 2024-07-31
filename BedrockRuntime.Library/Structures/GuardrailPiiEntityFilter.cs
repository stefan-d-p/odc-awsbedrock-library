using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A Personally Identifiable Information (PII) entity configured in a guardrail")]
public struct GuardrailPiiEntityFilter
{
    [OSStructureField(Description = "The PII entity filter action",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Action;
    
    [OSStructureField(Description = "The PII entity filter match",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Match;
    
    [OSStructureField(Description = "The PII entity filter type",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Type;
}