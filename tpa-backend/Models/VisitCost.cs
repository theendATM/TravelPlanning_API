using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class VisitCost
    {
        [Key]
        public int Id;

        public string Description { get; set; }

        public int Cost { get; set; }

        public Landmark Landmark { get; set; }
    }
}
