using System.Security.Cryptography;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "A system content block")]
public struct SystemContentBlock
{
    [OSStructureField(Description = "A system prompt for the model",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Text = String.Empty;

    public SystemContentBlock()
    {
        
    }

    public static SystemContentBlock Default => new SystemContentBlock();
}