using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Configuration information for a guardrail that you use with the Converse  Configuration information for a guardrail that you use with the Converse.")]
public struct GuardrailConfiguration
{
    [OSStructureField(Description = "Guardrail Identifier",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string GuardrailIdentifier = String.Empty;
    
    [OSStructureField(Description = "Guardrail Version",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string GuardrailVersion = String.Empty;
    
    [OSStructureField(Description = "Trace",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Trace = String.Empty;

    public GuardrailConfiguration()
    {
    }

    public static GuardrailConfiguration Default = new GuardrailConfiguration();
}