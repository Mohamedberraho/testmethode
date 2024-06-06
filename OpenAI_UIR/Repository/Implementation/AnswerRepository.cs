using OpenAI_UIR.Db;
using OpenAI_UIR.Models;
using OpenAI_UIR.Repository.Abstract;

namespace OpenAI_UIR.Repository.Implementation
{
    public class AnswerRepository : IAnswerRepository
    {
        public readonly AppDbContext _db;
        public AnswerRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            await _db.Answers.AddAsync(answer);
            await _db.SaveChangesAsync();
            return answer;
        }
    }
}
