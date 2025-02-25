using OutSystems.ExternalLibraries.SDK;
using Without.Systems.BedrockRuntime.Structures;

namespace Without.Systems.BedrockRuntime
{
    [OSInterface(
        Name = "AWSBedrockRuntime",
        Description = "AWS Bedrock Runtime SDK Wrapper. Build your own Generative AI applications with Amazon Bedrock Foundation Models and Agents.",
        IconResourceName = "Without.Systems.BedrockRuntime.Resources.AWSBedrock.png")]
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
            Description = "Invoke a Mistral Text Model",
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
            Description = "Invoke a Cohere Command Model",
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
            Description = "Invoke a Meta Llama Model",
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
                Description = "Amazon Titan Embeddings Model Identifier",
                DataType = OSDataType.Text)]
            string modelId,
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

        [OSAction(
            Description = "Create Images with Stability Diffusion 1.0",
            ReturnName = "response",
            ReturnDescription = "Embeddings response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.Stability.png")]
        StabilityDiffusionTextToImageResponse StabilityDiffusionTextToImage(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Stability Diffusion Request")]
            StabilityDiffusionTextToImageRequest request);

        [OSAction(
            Description = "Sends messages to the specified Amazon Bedrock model",
            ReturnName = "response",
            ReturnDescription = "Converse Response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.AWSBedrock.png")]
        ConverseResponse Converse(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Converse Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            ConverseRequest request);

        [OSAction(
            Description = "The action to apply a guardrail",
            ReturnName = "response",
            ReturnDescription = "Apply Guardrail Response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.AWSBedrock.png")]
        Structures.ApplyGuardrailResponse ApplyGuardrail(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Apply Guardrail Request structure",
                DataType = OSDataType.InferredFromDotNetType)]
            ApplyGuardrailRequest request);

        [OSAction(
            Description = "Direct Model Invocation",
            ReturnName = "response",
            ReturnDescription = "Model Invocation response",
            ReturnType = OSDataType.BinaryData,
            IconResourceName = "Without.Systems.BedrockRuntime.Resources.AWSBedrock.png")]
        public byte[] InvokeModel(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Model Identifier",
                DataType = OSDataType.Text)]
            string modelId,
            [OSParameter(
                Description = "Prompt payload as binary data",
                DataType = OSDataType.BinaryData)]
            byte[] payload,
            [OSParameter(
                Description = "Optional Guardrail Identifier",
                DataType = OSDataType.Text)]
            string guardRailIdentifier = "",
            [OSParameter(
                Description = "Guardail version",
                DataType = OSDataType.Text)]
            string guardRailVersion = "");

    }
}