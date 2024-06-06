using Azure;
using Azure.AI.OpenAI;
using Azure.Core;


namespace OpenAI_UIR.Services
{
    public class OpenAIService
    {
        private readonly OpenAIClient _client;

        public OpenAIService(string endpoint, string apiKey)
        {
            _client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
        }

        public async Task<string> GetAnswerAsync(string question)
        {
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "gpt-3.5-turbo",
                Messages ={
                    new ChatRequestSystemMessage("You are a helpful assistant. You will talk like a pirate."),
                    new ChatRequestUserMessage("Can you help me?"),
                    new ChatRequestAssistantMessage("Arrrr! Of course, me hearty! What can I do for ye?"),
                    new ChatRequestUserMessage("What's the best way to train a parrot?"),
                }
            };
            Response<ChatCompletions> response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
            return responseMessage.Content;
        }
    }
}
