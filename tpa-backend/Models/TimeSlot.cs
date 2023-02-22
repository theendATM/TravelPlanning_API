using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class TimeSlot
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Landmark? Landmark { get; set; }

        public bool? ObligitaryVisit { get; set; }

        public int? VisitTime { get; set; }




        public Day Day { get; set; }
    }
}
