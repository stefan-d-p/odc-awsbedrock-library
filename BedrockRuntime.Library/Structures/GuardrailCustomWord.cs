using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A custom word configured in a guardrail")]
public struct GuardrailCustomWord
{
    [OSStructureField(Description = "The action for the custom word",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Action;
    
    [OSStructureField(Description = "The match for the custom word",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Match;
    
    
}