# OutSystems Developer Cloud External Logic Connector Library for Amazon Bedrock Runtime

Amazon Bedrock is a fully managed service that offers a choice of high-performing foundation models (FMs) from leading AI companies like AI21 Labs, Anthropic, Cohere, Meta, Mistral AI, Stability AI, and Amazon through a single API, along with a broad set of capabilities you need to build generative AI applications with security, privacy, and responsible AI. Using Amazon Bedrock, you can easily experiment with and evaluate top FMs for your use case, privately customize them with your data using techniques such as fine-tuning and Retrieval Augmented Generation (RAG), and build agents that execute tasks using your enterprise systems and data sources. Since Amazon Bedrock is serverless, you don't have to manage any infrastructure, and you can securely integrate and deploy generative AI capabilities into your applications using the AWS services you are already familiar with.

This library wraps the the InvokeModel operation of the official .NET SDK for Amazon Bedrock and exposes actions for each model type to ODC for easy usage.

## Actions
The library exposes the following actions

### AnthropicClaude3Text

Invoke an Anthropic Claude 3 Text Model

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1). Make sure to specify a region where you have access to the models you want to use.
* `modelId` - The language model identifier you want to use. See model table.
* `request` - Anthropic Claude 3 model specific request structure.

**Result**

* `response` - Response structure 

### AmazonTitanText

Invoke an Amazon Titan Text Model

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1). Make sure to specify a region where you have access to the models you want to use.
* `modelId` - The language model identifier you want to use. See model table.
* `request` - Amazon Titan model specific request structure.

**Result**

* `response` - Response structure

### MistralText

Invoke a Mistral Instruct Model

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1). Make sure to specify a region where you have access to the models you want to use.
* `modelId` - The language model identifier you want to use. See model table.
* `request` - Mistral Instruct model specific request structure.

**Result**

* `response` - Response structure

### CohereCommandText

Invoke a Cohere Command Model

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1). Make sure to specify a region where you have access to the models you want to use.
* `modelId` - The language model identifier you want to use. See model table.
* `request` - Cohere Command model specific request structure.

**Result**

* `response` - Response structure

### MetaLlamaText

Invoke a Meta Llama Model

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1). Make sure to specify a region where you have access to the models you want to use.
* `modelId` - The language model identifier you want to use. See model table.
* `request` - Meta Llama model specific request structure.

**Result**

* `response` - Response structure

### AmazonTitanEmbeddings

Convert text to embeddings using Amazon Titan Embeddings model

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1). Make sure to specify a region where you have access to the models you want to use.
* `request` - Amazon Titan Embeddings specific request structure.

**Result**

* `response` - Response structure

### CohereEmbeddings

Convert text to embeddings using Cohere Embed

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1). Make sure to specify a region where you have access to the models you want to use.
* `modelId` - The language model identifier you want to use. See model table.
* `request` - Amazon Titan Embeddings specific request structure.

**Result**

* `response` - Response structure

### StabilityDiffusionTextToImage

Create Images with Stability Diffusion SDXL 1.0

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1). Make sure to specify a region where you have access to the models you want to use.
* `request` - Stability Diffusion specific request structure.

**Result**

* `response` - Response structure

## Model values

| Action               | Model Identifier                       | Model                |
|----------------------|----------------------------------------|----------------------|
| AnthropicClaude3Text | anthropic.claude-3-sonnet-20240229-v1:0 | Claude 3 Sonnet      |
|                      | anthropic.claude-3-haiku-20240307-v1:0 | Claude 3 Haiku       |
| AmazonTitanText      | amazon.titan-text-lite-v1              | Titan Text G1 Lite   |
|                      | amazon.titan-text-express-v1           | Titan Text G1 Express |
| MistralText          | mistral.mistral-7b-instruct-v0:2       | Mistral 7B Instruct  |
|                      | mistral.mixtral-8x7b-instruct-v0:1     | Mistral 8x7B Instruct |
|                      | mistral.mistral-large-2402-v1:0        | Mistral Large        |
| CohereCommandText    | cohere.command-text-v14                | Command              |
|                      | cohere.command-light-text-v14          | Command Light        |
| MetaLlamaText        | meta.llama3-8b-instruct-v1:0           | Llama 3 8B Instruct  |
|                      | meta.llama3-70b-instruct-v1:0          | Llama 3 70B Instruct |
|                      | meta.llama2-13b-chat-v1                | Llama 2 Chat 13B     |
|                      | meta.llama2-70b-chat-v1                | Llama 2 Chat 70B     |
| CohereEmbeddings     | cohere.embed-english-v3                | Embed English        |
|                      | cohere.embed-multilingual-v3           | Embed Multilingual   |