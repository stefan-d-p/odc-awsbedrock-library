using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Amazon.Runtime.Documents;
using AutoMapper;
using ThirdParty.Json.LitJson;

namespace Without.Systems.BedrockRuntime.Util;

public class JsonToDocumentConverter : IValueConverter<string, Document> 
{
    public Document Convert(string sourceMember, ResolutionContext context)
    {
        return Document.FromObject(JsonMapper.ToObject(sourceMember));
    }
    
    
}

public class DocumentToJsonConverter : IValueConverter<Document, string>
{
    public string Convert(Document sourceMember, ResolutionContext context)
    {
        return JsonSerializer.Serialize(sourceMember.AsDictionary());
        
    }

}