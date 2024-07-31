using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Information about a topic guardrail")]
public struct GuardrailTopic
{
    [OSStructureField(Description = "The action the guardrail should take when it intervenes on a topic",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Action;
    
    [OSStructureField(Description = "The name for the guardrail",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Name;
    
    [OSStructureField(Description = "The type behavior that the guardrail should perform when the model detects the topic",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Type;
}