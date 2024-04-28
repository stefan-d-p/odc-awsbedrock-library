using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "Response structure for Meta Llama Models")]
public struct MetaLlamaTextResponse
{
    [OSStructureField(
        Description = "The generated text",
        DataType = OSDataType.Text)]
    public string text;

    [OSStructureField(
        Description = "The number of tokens in the prompt",
        DataType = OSDataType.Integer)]
    public int PromptTokenCount;

    [OSStructureField(
        Description = "The number of tokens in the generated text",
        DataType = OSDataType.Integer)]
    public int GenerationTokenCount;

    [OSStructureField(
        Description =
            "The reason why the response stopped generating text. Possible values are:\nstop – The model has finished generating text for the input prompt.\nlength – The length of the tokens for the generated text exceeds the value of max_gen_len in the call to InvokeModel (InvokeModelWithResponseStream, if you are streaming output). The response is truncated to max_gen_len tokens. Consider increasing the value of max_gen_len and trying again.",
        DataType = OSDataType.Text)]
    public string StopReason;

}