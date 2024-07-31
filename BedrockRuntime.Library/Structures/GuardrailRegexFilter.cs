using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A Regex filter configured in a guardrail.")]
public struct GuardrailRegexFilter
{
    [OSStructureField(Description = "The region filter action",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Action;
    
    [OSStructureField(Description = "The regesx filter match",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Match;
    
    [OSStructureField(Description = "The regex filter name",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Name;
    
    [OSStructureField(Description = "The regex query",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Regex;
    
}