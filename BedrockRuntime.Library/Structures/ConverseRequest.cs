using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Container for the parameters to the Converse operation")]
public struct ConverseRequest
{
    [OSStructureField(Description = "The identifier for the model that you want to call",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ModelId;
    
    [OSStructureField(Description = "Additional model parameters field paths to return in the response",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<string>? AdditionalModelResponseFieldPaths;

    [OSStructureField(Description = "Inference parameters to pass to the model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public InferenceConfiguration? InferenceConfig;
    
    [OSStructureField(Description = "The messages that you want to send to the model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public List<Message> Messages;

    [OSStructureField(Description = "A system prompt to pass to the model",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<SystemContentBlock>? System;

    [OSStructureField(Description = "Configuration information for the tools that the model can use when generating a response",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public ToolConfiguration? ToolConfig;

}