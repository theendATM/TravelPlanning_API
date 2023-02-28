using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class Plan
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public City City { get; set; }

        public int? Budget { get; set; }
        public string? Location { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        public float? PlanDifficulty { get; set; }

        public DateTime? ExitTime { get; set; }
        public DateTime? ComingTime { get; set; }
        public IEnumerable<Difficulty>? Difficulties { get; set; }

        public IEnumerable<MovingType>? MovingTypes { get; set; }

        public IEnumerable<Day>? Days { get; set; }

        [Required]
        public User User { get; set; }




        public IEnumerable<PersonalLandmark>? PersonalLandmarks { get; set; }




    }
}
