using System.Security.Cryptography;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Message information")]
public struct Message
{
    [OSStructureField(Description = "The message content",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public List<ContentBlock> Content;
    
    [OSStructureField(Description = "The role that the message plays in the message. Valid values are user and assistant.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Role;
}