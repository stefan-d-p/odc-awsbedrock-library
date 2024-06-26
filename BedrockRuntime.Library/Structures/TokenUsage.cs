﻿using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.BedrockRuntime.Structures;

[OSStructure(Description = "The tokens used in a message API inference call")]
public struct TokenUsage
{
    [OSStructureField(Description = "The number of tokens sent in the request to the model",
        DataType = OSDataType.Integer)]
    public int InputTokens = 0;
    
    [OSStructureField(Description = "The number of tokens returned by the model",
        DataType = OSDataType.Integer)]
    public int OutputTokens = 0;
    
    [OSStructureField(Description = "The number of tokens used in the inference call",
        DataType = OSDataType.Integer)]
    public int TotalTokens = 0;

    public TokenUsage()
    {
        
    }

    public static TokenUsage Default => new TokenUsage();
}