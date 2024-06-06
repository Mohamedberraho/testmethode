using System.ComponentModel.DataAnnotations;

namespace OpenAI_UIR.Dtos
{
    public class QuestionDto
    {
        [Required]
        public string Question { get; set; }
    }
}
