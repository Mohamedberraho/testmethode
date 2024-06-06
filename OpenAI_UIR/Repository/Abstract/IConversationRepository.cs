using Microsoft.AspNetCore.Mvc;
using OpenAI_UIR.Models;

namespace OpenAI_UIR.Repository.Abstract
{
    public interface IConversationRepository
    {
        Task<Conversation> CreateConversation(Conversation conversation);
    }
}
