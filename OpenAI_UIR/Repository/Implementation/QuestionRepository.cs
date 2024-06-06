using Microsoft.AspNetCore.Mvc;
using OpenAI_UIR.Dtos;
using OpenAI_UIR.Models;
using OpenAI_UIR.Repository.Abstract;

namespace OpenAI_UIR.Repository.Implementation
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IConversationRepository _crepo;
        public QuestionRepository(IConversationRepository conversationRepository)
        {
            _crepo = conversationRepository;
        }
        public async Task<Question> CreateQuestion(QuestionDto questionDto)
        {
            Conversation conversation = new Conversation
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            };
            await _crepo.CreateConversation(conversation);
            return null;
        }
    }
}
