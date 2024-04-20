using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Anthropic Claude 3 model request structure")]
public struct AnthropicClaude3TextRequest
{
    [OSStructureField(
        Description = "The anthropic version. The value must be bedrock-2023-05-31",
        DataType = OSDataType.Text,
        DefaultValue = "bedrock-2023-05-31",
        IsMandatory = false)]
    public string Version;

    [OSStructureField(
        Description = "Maximum number of tokens",
        DataType = OSDataType.Integer,
        IsMandatory = true)]
    public int MaxTokens;
    
    [OSStructureField(
        Description = "Input messages",
        IsMandatory = true)]
    public List<AnthropicClaude3Message> Messages;
    
    [OSStructureField(
        Description = "The system prompt for the request.  A system prompt is a way of providing context and instructions to Anthropic Claude, such as specifying a particular goal or role",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? System;

    [OSStructureField(
        Description = "The temperature of the model. The value must be between 0.0 and 1.0",
        DefaultValue = "0.5",
        IsMandatory = false)]
    public float Temperature;

}

[OSStructure(
    Description = "Anthropic Claude 3 model message request structure")]
public struct AnthropicClaude3Message
{
    [OSStructureField(
        Description = "The role of the conversation turn. Valid values are user and assistant",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Role;
    
    [OSStructureField(
        Description = "The content of the conversation turn",
        IsMandatory = true)]
    public List<AnthropicClaude3ContentRequestItem> Content;
}

[OSStructure(
    Description = "Anthropic Claude 3 model content request structure")]
public struct AnthropicClaude3ContentRequestItem
{
    [OSStructureField(
        Description = "The type of the content. Valid values are image and text",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Type;
    
    [OSStructureField(
        Description = "Text content",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? Text;
    
    [OSStructureField(
        Description = "Source object",
        IsMandatory = false)]
    public AnthropicClaude3SourceRequest? Source;
}

[OSStructure(
    Description = "Anthropic Claude 3 model source request structure")]
public struct AnthropicClaude3SourceRequest
{
    [OSStructureField(
        Description = "The encoding type for the image.",
        DataType = OSDataType.Text,
        IsMandatory = false,
        DefaultValue = "base64")]
    public string Type;
    
    [OSStructureField(
        Description = "The type of the image. You can specify the following image formats.\nimage/jpeg\nimage/png\nimage/webp\nimage/gif",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string MediaType;
    
    [OSStructureField(
        Description = "The base64 encoded image bytes for the image. The maximum image size is 3.75MB. The maximum height and width of an image is 8000 pixels.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Data;
}