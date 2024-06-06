using System.ComponentModel.DataAnnotations;

namespace OpenAI_UIR.Models
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
