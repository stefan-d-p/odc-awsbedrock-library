using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Container for the parameters to the Converse operation")]
public struct ConverseRequest
{
    [OSStructureField(Description = "Guardrail Configuration",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public GuardrailConfiguration GuardrailConfig = GuardrailConfiguration.Default;
    
    [OSStructureField(Description = "The identifier for the model that you want to call",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ModelId = String.Empty;
    
    [OSStructureField(Description = "Additional model parameters field paths to return in the response",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<string> AdditionalModelResponseFieldPaths = new List<string>();

    [OSStructureField(Description = "Inference parameters to pass to the model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public InferenceConfiguration InferenceConfig = InferenceConfiguration.Default;

    [OSStructureField(Description = "The messages that you want to send to the model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public List<Message> Messages = new List<Message>();

    [OSStructureField(Description = "A system prompt to pass to the model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<SystemContentBlock> System = new List<SystemContentBlock>();

    [OSStructureField(
        Description = "Configuration information for the tools that the model can use when generating a response",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public ToolConfiguration ToolConfig = ToolConfiguration.Default;

    public ConverseRequest()
    {
        
    }

    public static ConverseRequest Default = new ConverseRequest();

}