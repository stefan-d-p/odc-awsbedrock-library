using System.Text.Json;
using Amazon.Runtime.Documents;
using AutoMapper;
using ThirdParty.Json.LitJson;

namespace Without.Systems.BedrockRuntime.Util;

public class ValueConverter : IValueConverter<string, Document> 
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
        var parse = ParseDocument(sourceMember);
        
        return JsonSerializer.Serialize(parse);
        
    }

    private Dictionary<string, object> ParseDocument(Document document)
    {
        var dictionary = document.AsDictionary();
        Dictionary<string, object> result = new Dictionary<string, object>();
        foreach (var keyDocument in dictionary)
        {
            switch (keyDocument.Value.Type)
            {
                case DocumentType.Bool:
                    result.Add(keyDocument.Key, keyDocument.Value.AsBool());
                    break;
                case DocumentType.Double:
                    result.Add(keyDocument.Key, keyDocument.Value.AsDouble());
                    break;
                case DocumentType.Int:
                    result.Add(keyDocument.Key, keyDocument.Value.AsInt());
                    break;
                case DocumentType.Long:
                    result.Add(keyDocument.Key, keyDocument.Value.AsLong());
                    break;
                case DocumentType.String:
                    result.Add(keyDocument.Key, keyDocument.Value.AsString());
                    break;
                case DocumentType.Dictionary:
                    result.Add(keyDocument.Key, ParseDocument(keyDocument.Value));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                
            }
        }
        return result;
    }

}