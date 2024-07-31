using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A managed word configured in a guardrail")]
public struct GuardrailManagedWord
{
    [OSStructureField(Description = "The action for the managed word",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Action;
    
    [OSStructureField(Description = "The match for the managed word",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Match;
    
    [OSStructureField(Description = "The type for the managed word",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Type;
}