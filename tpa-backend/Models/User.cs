using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Phone { get; set; }

        public IEnumerable<Tourist>? Tourists { get; set; }

        public IEnumerable<Plan>? Plans { get; set; }
    }
}
