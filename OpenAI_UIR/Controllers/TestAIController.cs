using Azure.AI.OpenAI;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace OpenAI_UIR.Controllers
{
    [ApiController]
    [Route("Api/OpenAI")]
    public class TestAIController
    {
        private readonly OpenAIClient _client;
        public TestAIController()
        {
            _client = new OpenAIClient(new Uri("https://zonetolearn.openai.azure.com/"), new AzureKeyCredential("c2c5da4808944d9c919071dceb1075f3"));
        }
        [HttpPost]
        public async Task<ActionResult<string>> GenerateResponse([FromBody] string userInput)
        {
            string apiKey = "c2c5da4808944d9c919071dceb1075f3";
            var openAIClient = new OpenAIClient(
                new Uri("https://zonetolearn.openai.azure.com/"),
                new AzureKeyCredential(apiKey));

            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "namodaj",
                Messages =
                {
                    // The system message represents instructions or other guidance about how the assistant should behave
                    new ChatRequestSystemMessage("You are a helpful assistant. You will talk like a pirate and respond in French."),
                    // User messages represent current or historical input from the end user
                    new ChatRequestUserMessage("Can you help me?"),
                    // Assistant messages represent historical responses from the assistant
                    new ChatRequestAssistantMessage("Arrrr! Of course, me hearty! What can I do for ye?"),
                    new ChatRequestUserMessage(userInput), // User's message
                }
            };

            Response<ChatCompletions> response = await openAIClient.GetChatCompletionsAsync(chatCompletionsOptions);
            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
            Console.WriteLine($"[{responseMessage.Role.ToString().ToUpperInvariant()}]: {responseMessage.Content}");

            return responseMessage.Content;
        }
    }
}
