using OutSystems.ExternalLibraries.SDK;
using Without.Systems.BedrockRuntime.Structures;

namespace Without.Systems.BedrockRuntime
{
    [OSInterface(
        Name = "AWSBedrockRuntime",
        Description = "AWS Bedrock Runtime SDK Wrapper. Build your own Generative AI applications with Amazon Bedrock Foundation Models and Agents.",
        IconResourceName = "Without.Systems.BedrockRuntime.Resources.BedrockRuntime.png")]
    public interface IBedrockRuntime
    {
        [OSAction(
            Description = "Invoke an Anthropic Claude 3 Text Model",
            ReturnName = "response",
            ReturnDescription = "Anthropic Claude 3 response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.Anthropic.png")]
        AnthropicClaude3TextResponse AnthropicClaude3Text(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Anthropic Claude 3 Model identifier",
                DataType = OSDataType.Text)]
            string modelId,
            [OSParameter(
                Description = "Anthropic Claude 3 Request structure",
                DataType = OSDataType.Text)]
            AnthropicClaude3TextRequest request);

        [OSAction(
            Description = "Invoke an Amazon Titan Text Model",
            ReturnName = "response",
            ReturnDescription = "Amazon Titan response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.Amazon.png")]
        AmazonTitanTextResponse AmazonTitanText(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Amazon Titan Text Model identifier",
                DataType = OSDataType.Text)]
            string modelId,
            [OSParameter(
                Description = "Amazon Titan Text Request structure")]
            AmazonTitanTextRequest request);

        [OSAction(
            Description = "Invoke an Mistral Text Model",
            ReturnName = "response",
            ReturnDescription = "Mistral response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.Mistral.png")]
        MistralTextResponse MistralText(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Amazon Titan Text Model identifier",
                DataType = OSDataType.Text)]
            string modelId,
            [OSParameter(
                Description = "Mistral Text Request structure")]
            MistralTextRequest request);

        [OSAction(
            Description = "Invoke an Cohere Command Model",
            ReturnName = "response",
            ReturnDescription = "Command response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.Cohere.png")]
        CohereCommandResponse CohereCommandText(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Cohere Command Model identifier",
                DataType = OSDataType.Text)]
            string modelId,
            [OSParameter(
                Description = "Cohere Command Request structure")]
            CohereCommandRequest request);
        
        [OSAction(
            Description = "Invoke an Meta Llama Model",
            ReturnName = "response",
            ReturnDescription = "Command response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.Meta.png")]
        MetaLlamaTextResponse MetaLlamaText(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Meta Llama Model identifier",
                DataType = OSDataType.Text)]
            string modelId,
            [OSParameter(
                Description = "Meta Llama Request structure")]
            MetaLlamaTextRequest request);

        [OSAction(
            Description = "Convert text to embeddings using Amazon Titan Embeddings model",
            ReturnName = "response",
            ReturnDescription = "Embeddings response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.Amazon.png")]
        AmazonTitanEmbeddingsResponse AmazonTitanEmbeddings(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Amazon Titan Embeddings Request")]
            AmazonTitanEmbeddingsRequest request);

        [OSAction(
            Description = "Convert text to embeddings using Cohere Embed",
            ReturnName = "response",
            ReturnDescription = "Embeddings response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.Cohere.png")]
        CohereEmbedResponse CohereEmbeddings(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Cohere Embed model identifier",
                DataType = OSDataType.Text)]
            string modelId,
            [OSParameter(
                Description = "Cohere Embed Request")]
            CohereEmbedRequest request);

    }
}