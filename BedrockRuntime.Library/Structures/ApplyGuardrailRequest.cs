using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Apply Guardrail Request Structure")]
public struct ApplyGuardrailRequest
{
    [OSStructureField(Description = "The content details used in the request to apply the guardrail",
        IsMandatory = true)]
    public List<GuardrailContentBlock> Content;

    [OSStructureField(Description = "The guardrail identifier used in the request to apply the guardrail",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string GuardrailIdentifier;
    
    [OSStructureField(Description = "The guardrail version used in the request to apply the guardrail",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string GuardrailVersion;

    [OSStructureField(Description = "The source of data used in the request to apply the guardrail",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Source;

}