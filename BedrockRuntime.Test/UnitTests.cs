using Microsoft.Extensions.Configuration;
using Without.Systems.BedrockRuntime.Structures;

namespace Without.Systems.BedrockRuntime.Test;

public class Tests
{
    private static readonly IBedrockRuntime _actions = new BedrockRuntime();

    private Credentials _credentials;
    private readonly string _awsRegion = "us-east-1";

    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();

        string awsAccessKey = configuration["AWSAccessKey"] ?? throw new InvalidOperationException();
        string awsSecretAccessKey = configuration["AWSSecretAccessKey"] ?? throw new InvalidOperationException();
        
        _credentials = new Credentials(awsAccessKey,awsSecretAccessKey);
    }

   
    [Test]
    public void Test_Anthropic_Claude3_Text()
    {
        AnthropicClaude3ContentRequestItem item = new AnthropicClaude3ContentRequestItem();
        item.Type = "text";
        item.Text = "What is the difference between a fish and a whale?";

        string model = "anthropic.claude-3-haiku-20240307-v1:0";
        
        AnthropicClaude3TextRequest request = new AnthropicClaude3TextRequest
        {
            Version = "bedrock-2023-05-31",
            MaxTokens = 2000,
            Messages = new List<AnthropicClaude3Message>()
        };
        request.Messages.Add(new AnthropicClaude3Message
        {
            Role = "user",
            Content = new List<AnthropicClaude3ContentRequestItem> { item }
        });

        

        var result =_actions.AnthropicClaude3Text(_credentials, _awsRegion, model, request);

        Assert.That(result.Model, Contains.Substring("claude-3-haiku"));

    }

    [Test]
    public void Test_Amazon_Titan_Text()
    {
        AmazonTitanTextConfiguration config = new AmazonTitanTextConfiguration
        {
            Temperature = 0.5f,
            MaxTokenCount = 512
        };
        
        AmazonTitanTextRequest request = new AmazonTitanTextRequest
        {
            InputText = "What is the difference between a fish and a whale?",
            Configuration = config
        };

        string model = "amazon.titan-text-lite-v1";

        var result = _actions.AmazonTitanText(_credentials, _awsRegion, model, request);
        Assert.That(result.InputTextTokenCount, Is.GreaterThan(0));
    }
    
    [Test]
    public void Mistral_Text_Generate()
    {
        MistralTextRequest request = new MistralTextRequest
        {
            Temperature = 0.5f,
            MaxTokens = 512,
            Prompt = "What is a whale?"
        };

        string model = "mistral.mistral-7b-instruct-v0:2";

        var result = _actions.MistralText(_credentials, _awsRegion, model, request);
    }

    [Test]
    public void Cohere_Command_Generate()
    {
        CohereCommandRequest request = new CohereCommandRequest
        {
            Prompt = "What is a whale?",
            MaxTokens = 400,
            Temperature = 0.9f,
            TopK = 0,
            TopP = 0.1f
        };

        string model = "cohere.command-text-v14";
        
        var result = _actions.CohereCommandText(_credentials, _awsRegion, model, request);
        
        Assert.That(result.Generations.Count,Is.Positive);
    }
    
    [Test]
    public void Meta_Llama_Generate()
    {
        MetaLlamaTextRequest request = new MetaLlamaTextRequest
        {
            Prompt = "What is a whale?",
            MaxTokens = 512,
            Temperature = 0.5f,
            TopP = 0.9f
        };

        string model = "meta.llama3-8b-instruct-v1:0";
        
        var result = _actions.MetaLlamaText(_credentials, _awsRegion, model, request);
        
        Assert.That(result.text,Is.Not.Empty);
    }

    [Test]
    public void Amazon_Titan_Embeddings_Convert()
    {
        AmazonTitanEmbeddingsRequest request = new AmazonTitanEmbeddingsRequest
        {
            InputText = "OutSystems is the leading high-performance low code application platform"
        };
        
        var result = _actions.AmazonTitanEmbeddings(_credentials, _awsRegion, request);
        Assert.That(result.Embedding.Count, Is.Positive);
    }
    
    [Test]
    public void Cohere_Embeddings_Convert()
    {
        CohereEmbedRequest request = new CohereEmbedRequest
        {
            Texts = new List<string> { "OutSystems is the leading high-performance low code application platform" },
            InputType = "search_document"
        };
        
        string model = "cohere.embed-english-v3";
        
        var result = _actions.CohereEmbeddings(_credentials, _awsRegion, model,request);
        Assert.That(result.Embeddings.Count, Is.Positive);
    }
    
}