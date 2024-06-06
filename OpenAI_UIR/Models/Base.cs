using System.ComponentModel.DataAnnotations;

namespace OpenAI_UIR.Models
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
