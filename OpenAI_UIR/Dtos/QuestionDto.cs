using System.ComponentModel.DataAnnotations;

namespace OpenAI_UIR.Dtos
{
    public class QuestionDto
    {
        [Required]
        public string? Question { get; set; }
        public string? Language { get; set; }
        public  string? ConversationId { get; set; }
    }
}
