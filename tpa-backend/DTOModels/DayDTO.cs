using System.Text.Json.Serialization;

namespace tpa_backend.DTOModels
{
    public class DayViewDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("date")]
        public DateOnly? DateTime { get; set; }

        [JsonPropertyName("weekDay")]
        public DayOfWeek? WeekDay { get; set; }

        [JsonPropertyName("time-slots")]
        public List<TimeSlotViewDTO>? TimeSlots { get; set; }
    }

    public class DayCreateDTO
    {

        [JsonPropertyName("date")]
        public DateOnly? DateTime { get; set; }

        [JsonPropertyName("weekDay")]
        public DayOfWeek? WeekDay { get; set; }

        [JsonPropertyName("time-slots")]
        public List<TimeSlotViewDTO>? TimeSlots { get; set; }
    }

    public class DayEditDTO
    {

        [JsonPropertyName("time-slots")]
        public List<TimeSlotViewDTO>? TimeSlots { get; set; }
    }
}
