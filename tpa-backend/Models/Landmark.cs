using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class Landmark
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public City City { get; set; }
        public IEnumerable<VisitCost>? VisitCosts { get; set; }
        [Required]
        public int? VisitTime { get; set; }
        public string? Address { get; set; }
        public IEnumerable<Interest>? Interests { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public float? NorthernLatitude { get; set; }
        public float? EasternLatitude { get; set; }

        //public IEnumerable<Day>? WorkingDays { get; set; }

        public Difficulty? Difficulty { get; set; }



    }
}
