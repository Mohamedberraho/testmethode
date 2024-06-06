using System.ComponentModel.DataAnnotations;

namespace OpenAI_UIR.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
