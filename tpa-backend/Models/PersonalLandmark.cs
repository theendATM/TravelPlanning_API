using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class PersonalLandmark
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }


        [Required]
        [MaxLength(3)]
        public int VisitTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

        public bool? ObligitaryVisit { get; set; }

        public Plan Plan { get; set; }

    }
}
