using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OpenAI_UIR.Dtos;
using OpenAI_UIR.Models;
using OpenAI_UIR.Repository.Abstract;
using OpenAI_UIR.Repository.Implementation;
using OpenAI_UIR.Services;

namespace OpenAI_UIR.Controllers
{
    [ApiController]
    [Route("/API/Question")]
    public class QuestionController
    {
        private readonly IConversationRepository _crepo;
        private readonly OpenAIService _openAI;
        protected APIResponse _response;
        public QuestionController(IConversationRepository conversationRepository, OpenAIService openAIService)
        {
            _crepo = conversationRepository;
            _openAI = openAIService;
        }
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateQuestion([] QuestionDto questionDto) {
            Conversation conversation;
            Guid conversationId;
            if (Guid.TryParse(questionDto.ConversationId, out conversationId))
            {
                conversation = new Conversation
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                };
                await _crepo.CreateConversation(conversation);
            }
            else
            {
                conversation = await _crepo.GetConversationAsync(conversationId);
                if (conversation == null)
                {
                    throw new Exception("Conversation not found");
                }
            }
            var question = new Question
            {
                Id = Guid.NewGuid(),
                QuestionContent = questionDto.Question,
                CreatedAt = DateTime.UtcNow,
                ConversationId = conversation.Id,
                Conversation = conversation
            };


            return ;
        }
    }
}
