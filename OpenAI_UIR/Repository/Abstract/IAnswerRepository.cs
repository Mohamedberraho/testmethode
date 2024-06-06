using OpenAI_UIR.Models;

namespace OpenAI_UIR.Repository.Abstract
{
    public interface IAnswerRepository
    {
        Task<Answer> CreateAnswerAsync(Answer answer);
    }
}
