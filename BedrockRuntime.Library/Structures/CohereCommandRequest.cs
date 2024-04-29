using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(
    Description = "Cohere Command Model Request")]
public struct CohereCommandRequest
{
    [OSStructureField(
        Description = "Input Text",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Prompt;
    
    [OSStructureField(
        Description = "Specify the maximum number of tokens to use in the generated response.",
        DataType = OSDataType.Integer,
        IsMandatory = false,
        DefaultValue = "400")]
    public int MaxTokens;
    
    [OSStructureField(
        Description = "Use a lower value to decrease randomness in the response. Default 0.9",
        IsMandatory = false,
        DefaultValue = "0.9")]
    public float Temperature;
    
    [OSStructureField(
        Description = "Use a lower value to ignore less probable options. Set to 0 or 1.0 to disable. If both TopP and TopK are enabled, TopP acts after TopK.",
        IsMandatory = false,
        DefaultValue = "0.01")]
    public float TopP;
    
    [OSStructureField(
        Description = "Specify the number of token choices the model uses to generate the next token. If both TopP and TopK are enabled, TopP acts after TopK.",
        IsMandatory = false,
        DefaultValue = "0")]
    public int TopK;
}

[OSStructure(
    Description = "Cohere Embed Model Request")]
public struct CohereEmbedRequest
{
    [OSStructureField(
        Description =
            "(Required) An array of strings for the model to embed. For optimal performance, we recommend reducing the length of each text to less than 512 tokens. 1 token is about 4 characters.\n\nThe following are text per call and character limits.",
        IsMandatory = true)]
    public List<string> Texts;
    
    [OSStructureField(
        Description = "Prepends special tokens to differentiate each type from one another. You should not mix different types together, except when mixing types for for search and retrieval. In this case, embed your corpus with the search_document type and embedded queries with type search_query type.\n\nsearch_document – In search use-cases, use search_document when you encode documents for embeddings that you store in a vector database.\n\nsearch_query – Use search_query when querying your vector DB to find relevant documents.\n\nclassification – Use classification when using embeddings as an input to a text classifier.\n\nclustering – Use clustering to cluster the embeddings.",
        IsMandatory = true)]
    public string InputType;
    
    [OSStructureField(
        Description = "Specifies how the API handles inputs longer than the maximum token length. Use one of the following:\n\nNONE – (Default) Returns an error when the input exceeds the maximum input token length.\n\nSTART – Discards the start of the input.\n\nEND – Discards the end of the input.",
        IsMandatory = false,
        DefaultValue = "NONE")]
    public string Truncate;
}