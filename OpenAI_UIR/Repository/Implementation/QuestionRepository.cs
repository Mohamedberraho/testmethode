using Microsoft.AspNetCore.Mvc;
using OpenAI_UIR.Db;
using OpenAI_UIR.Dtos;
using OpenAI_UIR.Models;
using OpenAI_UIR.Repository.Abstract;

namespace OpenAI_UIR.Repository.Implementation
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _db;
        public QuestionRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Question> CreateQuestionAsync(Question question)
        {
            await _db.Questions.AddAsync(question);
            await _db.SaveChangesAsync();
            return question;
        }

        
    }
}
