using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Amazon;
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;
using AutoMapper;
using Without.Systems.BedrockRuntime.Extensions;
using Without.Systems.BedrockRuntime.Models;
using Without.Systems.BedrockRuntime.Structures;
using Without.Systems.BedrockRuntime.Util;

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

    private MemoryStream InvokeModel(Credentials credentials, string region, string modelId, MemoryStream payload)
    {
        AmazonBedrockRuntimeClient client =
            new AmazonBedrockRuntimeClient(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));

        InvokeModelRequest request = new InvokeModelRequest();
        request.ContentType = MediaTypeNames.Application.Json;
        request.ModelId = modelId;
        request.Body = payload;

        InvokeModelResponse response = AsyncUtil.RunSync(() => client.InvokeModelAsync(request));

        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) ||
              response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error invoking model with status code {response.HttpStatusCode}");

        return response.Body;
    } 
}