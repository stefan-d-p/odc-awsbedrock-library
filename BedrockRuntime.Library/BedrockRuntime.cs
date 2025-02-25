﻿using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Amazon;
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;
using Amazon.Runtime.Documents;
using AutoMapper;
using ThirdParty.Json.LitJson;
using Without.Systems.BedrockRuntime.Extensions;
using Without.Systems.BedrockRuntime.Models;
using Without.Systems.BedrockRuntime.Structures;
using Without.Systems.BedrockRuntime.Util;
using ImageBlock = Without.Systems.BedrockRuntime.Structures.ImageBlock;
using InferenceConfiguration = Without.Systems.BedrockRuntime.Structures.InferenceConfiguration;
using ToolConfiguration = Without.Systems.BedrockRuntime.Structures.ToolConfiguration;
using ToolResultBlock = Without.Systems.BedrockRuntime.Structures.ToolResultBlock;
using ToolUseBlock = Without.Systems.BedrockRuntime.Structures.ToolUseBlock;

namespace Without.Systems.BedrockRuntime;

public class BedrockRuntime : IBedrockRuntime
{
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        IncludeFields = true
    };

    private readonly IMapper _automapper;

    public BedrockRuntime()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;

            cfg.CreateMap<Structures.ConverseRequest, Amazon.BedrockRuntime.Model.ConverseRequest>()
                .ForMember(dest => dest.System, opt => opt.Condition(src => src.System.Count > 0))
                .ForMember(dest => dest.InferenceConfig,
                    opt => opt.Condition(src => !InferenceConfiguration.Default.Equals(src.InferenceConfig)))
                .ForMember(dest => dest.ToolConfig,
                    opt => opt.Condition(src => !ToolConfiguration.Default.Equals(src.ToolConfig)))
                .ForMember(dest => dest.AdditionalModelResponseFieldPaths,
                    opt => opt.Condition(src => src.AdditionalModelResponseFieldPaths.Count > 0))
                .ForMember(dest => dest.GuardrailConfig, opt => opt.Condition(src => !string.IsNullOrEmpty(src.GuardrailConfig.GuardrailIdentifier)));
                
            
            cfg.CreateMap<AmazonTitanTextRequest, AmazonTitanTextRequestDto>();
            cfg.CreateMap<AmazonTitanTextConfiguration, AmazonTitanTextConfigurationDto>();

            cfg.CreateMap<AmazonTitanTextResponseDto, AmazonTitanTextResponse>();
            cfg.CreateMap<AmazonTitanTextResultItemDto, AmazonTitanTextResultItem>();

            cfg.CreateMap<AnthropicClaude3TextRequest, AnthropicClaude3TextRequestDto>();
            cfg.CreateMap<AnthropicClaude3Message, AnthropicClaude3MessageDto>();
            cfg.CreateMap<AnthropicClaude3SourceRequest, AnthropicClaude3SourceRequestDto>();
            cfg.CreateMap<AnthropicClaude3ContentRequestItem, AnthropicClaude3ContentRequestItemDto>()
                .ForMember(destination => destination.Source,
                    options => options.Condition(source => source.Type == "image"));

            cfg.CreateMap<AnthropicClaude3TextResponseDto, AnthropicClaude3TextResponse>();
            cfg.CreateMap<AnthropicClaude3ContentResponseItemDto, AnthropicClaude3ContentResponseItem>();
            cfg.CreateMap<AnthropicClaude3UsageDto, AnthropicClaude3Usage>();

            cfg.CreateMap<MistralTextRequest, MistralTextRequestDto>()
                .AfterMap((source, destination) =>
                {
                    // Wrapping the source prompt if it does not include s INST
                    if (!source.Prompt.StartsWith("<s>"))
                    {
                        destination.Prompt = $"<s>[INST]{source.Prompt}[/INST]";
                    }
                });

            cfg.CreateMap<MistralTextResponseDto, MistralTextResponse>();
            cfg.CreateMap<MistralTextOutputItemDto, MistralTextOutputItem>();

            cfg.CreateMap<CohereCommandRequest, CohereCommandRequestDto>();
            cfg.CreateMap<CohereCommandResponseDto, CohereCommandResponse>();
            cfg.CreateMap<CohereCommandGenerationDto, CohereCommandGeneration>();

            cfg.CreateMap<MetaLlamaTextRequest, MetaLlamaTextRequestDto>();
            cfg.CreateMap<MetaLlamaTextResponseDto, MetaLlamaTextResponse>();

            cfg.CreateMap<AmazonTitanEmbeddingsRequest, AmazonTitanEmbeddingsRequestDto>();
            cfg.CreateMap<AmazonTitanEmbeddingsResponseDto, AmazonTitanEmbeddingsResponse>();

            cfg.CreateMap<CohereEmbedRequest, CohereEmbedRequestDto>();
            cfg.CreateMap<CohereEmbedResponseDto, CohereEmbedResponse>();

            cfg.CreateMap<List<float>, Vector>()
                .ForMember(destination => destination.Embedding, opt => opt.MapFrom(src => src));
            
            cfg.CreateMap<StabilityDiffusionTextToImageRequest, StabilityDiffusionTextToImageRequestDto>();
            cfg.CreateMap<StabilityDiffusionTextPrompt, StabilityDiffusionTextPromptDto>();
            cfg.CreateMap<StabilityDiffusionTextToImageResponseDto, StabilityDiffusionTextToImageResponse>();
            cfg.CreateMap<StabilityDiffusionArtifactDto, StabilityDiffusionArtifact>()
                .ForMember(destination => destination.Image,
                    opt => opt.MapFrom(source => Convert.FromBase64String(source.Image)));


            cfg.CreateMap<Structures.InferenceConfiguration, Amazon.BedrockRuntime.Model.InferenceConfiguration>();
            cfg.CreateMap<Structures.ImageBlock, Amazon.BedrockRuntime.Model.ImageBlock>()
                .ForMember(dest => dest.Format, opt => opt.MapFrom(src => ImageFormat.FindValue(src.Format)));
            cfg.CreateMap<Amazon.BedrockRuntime.Model.ImageBlock, Structures.ImageBlock>();
            
            cfg.CreateMap<Structures.ImageSource, Amazon.BedrockRuntime.Model.ImageSource>()
                .ForMember(dest => dest.Bytes, opt => opt.MapFrom(src => new MemoryStream(src.Data!)));
            cfg.CreateMap<Amazon.BedrockRuntime.Model.ImageSource, Structures.ImageSource>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Bytes.ToArray()));
            cfg.CreateMap<Structures.ToolResultContentBlock, Amazon.BedrockRuntime.Model.ToolResultContentBlock>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.ToolResultContentBlock, Structures.ToolResultContentBlock>();
            cfg.CreateMap<Structures.ToolResultBlock, Amazon.BedrockRuntime.Model.ToolResultBlock>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ToolResultStatus.FindValue(src.Status)));
            cfg.CreateMap<Amazon.BedrockRuntime.Model.ToolResultBlock, Structures.ToolResultBlock>();
            cfg.CreateMap<Structures.ToolUseBlock, Amazon.BedrockRuntime.Model.ToolUseBlock>();

            cfg.CreateMap<Amazon.BedrockRuntime.Model.ToolUseBlock, Structures.ToolUseBlock>()
                .ForMember(dest => dest.Input, opt => opt.Condition(src => src != null))
                .ForMember(dest => dest.Input, opt => opt.ConvertUsing<Document>(new DocumentToJsonConverter()));
            cfg.CreateMap<Structures.ContentBlock, Amazon.BedrockRuntime.Model.ContentBlock>()
                .ForMember(dest => dest.Image, opt => opt.Condition(src => !ImageBlock.Default.Equals(src.Image)))
                .ForMember(dest => dest.Text, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Text)))
                .ForMember(dest => dest.ToolResult,
                    opt => opt.Condition(src => !ToolResultBlock.Default.Equals(src.ToolResult)))
                .ForMember(dest => dest.ToolUse,
                    opt => opt.Condition(src => !ToolUseBlock.Default.Equals(src.ToolUse)));
            cfg.CreateMap<Amazon.BedrockRuntime.Model.ContentBlock, Structures.ContentBlock>();
            
            cfg.CreateMap<Structures.Message, Amazon.BedrockRuntime.Model.Message>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => ConversationRole.FindValue(src.Role)));
            cfg.CreateMap<Amazon.BedrockRuntime.Model.Message, Structures.Message>();
            
            
            cfg.CreateMap<Structures.SystemContentBlock, Amazon.BedrockRuntime.Model.SystemContentBlock>();
            cfg.CreateMap<Structures.ToolInputSchema, Amazon.BedrockRuntime.Model.ToolInputSchema>()
                .ForMember(dest => dest.Json, opt => opt.ConvertUsing<string>(new ValueConverter()));

            cfg.CreateMap<Structures.ToolSpecification, Amazon.BedrockRuntime.Model.ToolSpecification>();
            cfg.CreateMap<Structures.Tool, Amazon.BedrockRuntime.Model.Tool>();
            cfg.CreateMap<Structures.ToolConfiguration, Amazon.BedrockRuntime.Model.ToolConfiguration>();

            cfg.CreateMap<Amazon.BedrockRuntime.Model.ConverseMetrics, Structures.ConverseMetrics>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.TokenUsage, Structures.TokenUsage>();

            cfg.CreateMap<Amazon.BedrockRuntime.Model.ConverseOutput, Structures.ConverseOutput>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.ConverseResponse, Structures.ConverseResponse>();

            cfg.CreateMap<Structures.GuardrailTextBlock, Amazon.BedrockRuntime.Model.GuardrailTextBlock>();
            cfg.CreateMap<Structures.GuardrailContentBlock, Amazon.BedrockRuntime.Model.GuardrailContentBlock>();
            cfg.CreateMap<Structures.ApplyGuardrailRequest, Amazon.BedrockRuntime.Model.ApplyGuardrailRequest>()
                .ForMember(dest => dest.Source,
                    opt => opt.MapFrom(src => GuardrailContentSource.FindValue(src.Source)));

            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailContentFilter, Structures.GuardrailContentFilter>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailContentPolicyAssessment,
                Structures.GuardrailContentPolicyAssessment>();

            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailContextualGroundingFilter,
                Structures.GuardrailContextualGroundingFilter>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailContextualGroundingPolicyAssessment,
                Structures.GuardrailContextualGroundingPolicyAssessment>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailPiiEntityFilter, Structures.GuardrailPiiEntityFilter>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailRegexFilter, Structures.GuardrailRegexFilter>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailSensitiveInformationPolicyAssessment,
                Structures.GuardrailSensitiveInformationPolicyAssessment>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailTopic, Structures.GuardrailTopic>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailTopicPolicyAssessment,
                Structures.GuardrailTopicPolicyAssessment>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailCustomWord, Structures.GuardrailCustomWord>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailManagedWord, Structures.GuardrailManagedWord>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailWordPolicyAssessment,
                Structures.GuardrailWordPolicyAssessment>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailAssessment, Structures.GuardrailAssessment>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailOutputContent, Structures.GuardrailOutputContent>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.GuardrailUsage, Structures.GuardrailUsage>();
            cfg.CreateMap<Amazon.BedrockRuntime.Model.ApplyGuardrailResponse, Structures.ApplyGuardrailResponse>();

            cfg.CreateMap<Structures.GuardrailConfiguration, Amazon.BedrockRuntime.Model.GuardrailConfiguration>()
                .ForMember(dest => dest.GuardrailIdentifier,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.GuardrailIdentifier)))
                .ForMember(dest => dest.GuardrailVersion,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.GuardrailVersion)))
                .ForMember(dest => dest.Trace, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.Trace));
                    opt.MapFrom(src => GuardrailTrace.FindValue(src.Trace));
                });

        });

        _automapper = mapperConfiguration.CreateMapper();
    }

    public CohereCommandResponse CohereCommandText(Credentials credentials, string region, string modelId,
        CohereCommandRequest request)
    {
        var dtoRequest = _automapper.Map<CohereCommandRequestDto>(request);
        using (MemoryStream payload = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(dtoRequest, _serializerOptions)))
        using (MemoryStream response = InvokeModel(credentials, region, modelId, payload))
        {
            var dtoResponse = JsonSerializer.Deserialize<CohereCommandResponseDto>(Encoding.UTF8.GetString(response.ToArray()), _serializerOptions);
            return _automapper.Map<CohereCommandResponse>(dtoResponse);
        }
    }
    
    public MistralTextResponse MistralText(Credentials credentials, string region, string modelId,
        MistralTextRequest request)
    {
        var dtoRequest = _automapper.Map<MistralTextRequestDto>(request);
        using (MemoryStream payload = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(dtoRequest, _serializerOptions)))
        using (MemoryStream response = InvokeModel(credentials, region, modelId, payload))
        {
            var dtoResponse = JsonSerializer.Deserialize<MistralTextResponseDto>(Encoding.UTF8.GetString(response.ToArray()), _serializerOptions);
            return _automapper.Map<MistralTextResponse>(dtoResponse);
        }
    }

    public AnthropicClaude3TextResponse AnthropicClaude3Text(Credentials credentials, string region, string modelId,
        AnthropicClaude3TextRequest request)
    {
        var dtoRequest = _automapper.Map<AnthropicClaude3TextRequestDto>(request);
        
        using (MemoryStream payload = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(dtoRequest, _serializerOptions)))
        using (MemoryStream response = InvokeModel(credentials, region, modelId, payload))
        {
            var dtoResponse = JsonSerializer.Deserialize<AnthropicClaude3TextResponseDto>(Encoding.UTF8.GetString(response.ToArray()), _serializerOptions);
            return _automapper.Map<AnthropicClaude3TextResponse>(dtoResponse);
        }
    }

    public MetaLlamaTextResponse MetaLlamaText(Credentials credentials, string region, string modelId,
        MetaLlamaTextRequest request)
    {
        var dtoRequest = _automapper.Map<MetaLlamaTextRequestDto>(request);
        using (MemoryStream payload = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(dtoRequest, _serializerOptions)))
        using (MemoryStream response = InvokeModel(credentials, region, modelId, payload))
        {
            var dtoResponse = JsonSerializer.Deserialize<MetaLlamaTextResponseDto>(Encoding.UTF8.GetString(response.ToArray()), _serializerOptions);
            return _automapper.Map<MetaLlamaTextResponse>(dtoResponse);
        }
        
    }

    public AmazonTitanTextResponse AmazonTitanText(Credentials credentials, string region, string modelId,
        AmazonTitanTextRequest request)
    {
        var dtoRequest = _automapper.Map<AmazonTitanTextRequestDto>(request);
        
        using (MemoryStream payload = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(dtoRequest, _serializerOptions)))
        using (MemoryStream response = InvokeModel(credentials, region, modelId, payload))
        {
            var dtoResponse = JsonSerializer.Deserialize<AmazonTitanTextResponseDto>(Encoding.UTF8.GetString(response.ToArray()), _serializerOptions);
            return _automapper.Map<AmazonTitanTextResponse>(dtoResponse);
        }
    }

    public CohereEmbedResponse CohereEmbeddings(Credentials credentials, string region, string modelId,
        CohereEmbedRequest request)
    {
        var dtoRequest = _automapper.Map<CohereEmbedRequestDto>(request);
        
        using (MemoryStream payload = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(dtoRequest, _serializerOptions)))
        using (MemoryStream response = InvokeModel(credentials, region, modelId, payload))
        {
            var dtoResponse = JsonSerializer.Deserialize<CohereEmbedResponseDto>(Encoding.UTF8.GetString(response.ToArray()), _serializerOptions);
            return _automapper.Map<CohereEmbedResponse>(dtoResponse);
        }
    }

    public AmazonTitanEmbeddingsResponse AmazonTitanEmbeddings(Credentials credentials, string region, string modelId,
        AmazonTitanEmbeddingsRequest request)
    {
        var dtoRequest = _automapper.Map<AmazonTitanEmbeddingsRequestDto>(request);
        
        using (MemoryStream payload = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(dtoRequest, _serializerOptions)))
        using (MemoryStream response = InvokeModel(credentials, region, modelId, payload))
        {
            var dtoResponse = JsonSerializer.Deserialize<AmazonTitanEmbeddingsResponseDto>(Encoding.UTF8.GetString(response.ToArray()), _serializerOptions);
            return _automapper.Map<AmazonTitanEmbeddingsResponse>(dtoResponse);
        }
    }

    public StabilityDiffusionTextToImageResponse StabilityDiffusionTextToImage(Credentials credentials, string region,
        StabilityDiffusionTextToImageRequest request)
    {
        const string modelId = "stability.stable-diffusion-xl-v1";
        var dtoRequest = _automapper.Map<StabilityDiffusionTextToImageRequestDto>(request);
        
        using (MemoryStream payload = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(dtoRequest, _serializerOptions)))
        using (MemoryStream response = InvokeModel(credentials, region, modelId, payload))
        {
            var dtoResponse = JsonSerializer.Deserialize<StabilityDiffusionTextToImageResponseDto>(Encoding.UTF8.GetString(response.ToArray()), _serializerOptions);
            return _automapper.Map<StabilityDiffusionTextToImageResponse>(dtoResponse);
        }
    }
    
    public Structures.ConverseResponse Converse(Credentials credentials, string region, Structures.ConverseRequest request)
    {
        var dtoRequest = _automapper.Map<Amazon.BedrockRuntime.Model.ConverseRequest>(request);
 
        AmazonBedrockRuntimeClient client =
            new AmazonBedrockRuntimeClient(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));
        
        var response = AsyncUtil.RunSync(() => client.ConverseAsync(dtoRequest));

        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) ||
              response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error invoking model with status code {response.HttpStatusCode}");

        return _automapper.Map<Structures.ConverseResponse>(response);
    }

    public Structures.ApplyGuardrailResponse ApplyGuardrail(Credentials credentials, string region,
        Structures.ApplyGuardrailRequest request)
    {
        var dtoRequest = _automapper.Map<Amazon.BedrockRuntime.Model.ApplyGuardrailRequest>(request);

        AmazonBedrockRuntimeClient client =
            new AmazonBedrockRuntimeClient(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));

        var response = AsyncUtil.RunSync(() => client.ApplyGuardrailAsync(dtoRequest));

        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) ||
              response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error invoking model with status code {response.HttpStatusCode}");

        return _automapper.Map<Structures.ApplyGuardrailResponse>(response);
    }

    public byte[] InvokeModel(Credentials credentials, string region, string modelId, byte[] payload,
        string guardRailIdentifier = "", string guardRailVersion = "")
    {
        AmazonBedrockRuntimeClient client =
            new AmazonBedrockRuntimeClient(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));

        InvokeModelRequest request = new InvokeModelRequest
        {
            ContentType = MediaTypeNames.Application.Json,
            ModelId = modelId,
            Body = new MemoryStream(payload)
        };

        /*
         * Guardrail Configuration
         */

        if (!string.IsNullOrEmpty(guardRailIdentifier)) request.GuardrailIdentifier = guardRailIdentifier;
        if (!string.IsNullOrEmpty(guardRailVersion)) request.GuardrailVersion = guardRailVersion;

        InvokeModelResponse response = AsyncUtil.RunSync(() => client.InvokeModelAsync(request));

        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) ||
              response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error invoking model with status code {response.HttpStatusCode}");

        return response.Body.ToArray();
    }
 
    private MemoryStream InvokeModel(Credentials credentials, string region, string modelId, MemoryStream payload, string guardRailIdentifier = "", string guardRailVersion = "")
    {
        AmazonBedrockRuntimeClient client =
            new AmazonBedrockRuntimeClient(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));

        InvokeModelRequest request = new InvokeModelRequest
        {
            ContentType = MediaTypeNames.Application.Json,
            ModelId = modelId,
            Body = payload
        };

        /*
         * Guardrail Configuration
         */

        if (!string.IsNullOrEmpty(guardRailIdentifier)) request.GuardrailIdentifier = guardRailIdentifier;
        if (!string.IsNullOrEmpty(guardRailVersion)) request.GuardrailVersion = guardRailVersion;

        InvokeModelResponse response = AsyncUtil.RunSync(() => client.InvokeModelAsync(request));

        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) ||
              response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error invoking model with status code {response.HttpStatusCode}");

        return response.Body;
    } 
}