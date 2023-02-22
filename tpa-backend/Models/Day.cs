using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class Day
    {
        [Key]
        public Guid Id { get; set; }


        public DateTime? DateTime { get; set; }
        public DayOfWeek? WeekDay { get; set; }

        public IEnumerable<TimeSlot>? TimeSlots { get; set; }

        public Landmark? LandmarkWorkingHours { get; set; }
    }
}
