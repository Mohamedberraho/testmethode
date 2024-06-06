using System.Net;
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
        private readonly IQuestionRepository _qrepo;
        private readonly IAnswerRepository _arepo;
        private readonly OpenAIService _openAI;
        protected APIResponse _response;
        public QuestionController(IConversationRepository conversationRepository, OpenAIService openAIService,IQuestionRepository questionRepository,IAnswerRepository answerRepository)
        {
            _arepo = answerRepository;
            _crepo = conversationRepository;
            _openAI = openAIService;
            _qrepo = questionRepository;
            _response = new();
        }
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateQuestion([FromBody] QuestionDto questionDto) {
            if (questionDto == null || string.IsNullOrEmpty(questionDto.Question))
            {
                _response.CodeStatus = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Invalid question data.");
                return _response;
            }
            Conversation conversation;
            Guid conversationId = Guid.Parse(questionDto.ConversationId);
            
            if (await _crepo.GetConversationAsync(conversationId) == null)
            {
                conversation = new Conversation
                {
                    Id = conversationId,
                    CreatedAt = DateTime.UtcNow,
                };
                await _crepo.CreateConversationAsync(conversation);
            }
            else
            {
                conversation = await _crepo.GetConversationAsync(conversationId);
                if (conversation == null)
                {
                    _response.CodeStatus = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Conversation not found.");
                    return _response;
                }
            }
            Question question = new Question
            {
                Id = Guid.NewGuid(),
                QuestionContent = questionDto.Question,
                CreatedAt = DateTime.UtcNow,
                ConversationId = conversation.Id,
            };
            await _qrepo.CreateQuestionAsync(question);
            string response = await _openAI.GetAnswerAsync(question.QuestionContent , questionDto.Language);
            Answer answer = new Answer
            {
                Id = Guid.NewGuid(),
                AnswerContent = response,
                QuestionId = question.Id,
                CreatedAt = DateTime.UtcNow,
            };
            await _arepo.CreateAnswerAsync(answer);
            _response.CodeStatus = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.ErrorMessages.Add("Question and answer created successfully.");
            _response.Result = new
            {
                Question = question,
                Answer = answer,
                ConversationId = conversation.Id
            };
            return _response;
        }
    }
}
