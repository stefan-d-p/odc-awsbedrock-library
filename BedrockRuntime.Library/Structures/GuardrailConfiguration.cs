using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Configuration information for a guardrail that you use with the Converse  Configuration information for a guardrail that you use with the Converse.")]
public struct GuardrailConfiguration
{
    [OSStructureField(Description = "Guardrail Identifier",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string GuardrailIdentifier;
    
    [OSStructureField(Description = "Guardrail Version",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string GuardrailVersion;
    
    [OSStructureField(Description = "Trace",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Trace;
}