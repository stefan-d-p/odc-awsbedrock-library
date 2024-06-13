using System.Security.Cryptography;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Guardrail Invoke Model Configuration")]
public struct Guardrail
{
    [OSStructureField(Description = "The unique identifier of the guardrail that you want to use",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string GuardrailIdentifier;
    
    [OSStructureField(Description = "The version number for the guardrail. The value can also be DRAFT",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string GuardrailVersion;
}