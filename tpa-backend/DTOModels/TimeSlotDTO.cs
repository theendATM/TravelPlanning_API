using System.Text.Json.Serialization;

namespace tpa_backend.DTOModels
{
    public class TimeSlotViewDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("start-time")]
        public TimeOnly StartTime { get; set; }

        [JsonPropertyName("end-time")]
        public TimeOnly EndTime { get; set; }

        [JsonPropertyName("obligitary-visit")]
        public bool? ObligitaryVisit { get; set; }

        [JsonPropertyName("visit-time")]
        public int? VisitTime { get; set; }

        public LandmarkViewDTO? Landmark { get; set; }

    }

    public class TimeSlotCreateEditDTO
    {

        [JsonPropertyName("start-time")]
        public TimeOnly StartTime { get; set; }

        [JsonPropertyName("end-time")]
        public TimeOnly EndTime { get; set; }

        [JsonPropertyName("obligitary-visit")]
        public bool? ObligitaryVisit { get; set; }

        [JsonPropertyName("visit-time")]
        public int? VisitTime { get; set; }

        public LandmarkViewDTO? Landmark { get; set; }

    }
}
