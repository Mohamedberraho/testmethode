using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OpenAI_UIR.Db;
using OpenAI_UIR.Models;
using OpenAI_UIR.Repository.Abstract;

namespace OpenAI_UIR.Repository.Implementation
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly AppDbContext _db;
        public ConversationRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Conversation> CreateConversation(Conversation conversation)
        {
            await _db.Conversations.AddAsync(conversation);
            _db.SaveChanges();
            return conversation;
        }
    }
}
