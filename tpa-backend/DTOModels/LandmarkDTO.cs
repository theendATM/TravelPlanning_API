using System.Text.Json.Serialization;
using tpa_backend.Models;

namespace tpa_backend.DTOModels
{
    public class LandmarkViewDTO
    {
        //[JsonPropertyName("id")]
        //public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("cost")]
        public List<VisitCost>? VisitCost { get; set; }

        [JsonPropertyName("visit-time")]
        public int? VisitTime { get; set; }

        //[JsonPropertyName("address")]
        //public string? Address { get; set; }

        [JsonPropertyName("interests")]
        public List<Interest>? Interests { get; set; }

        [JsonPropertyName("min-age")]
        public int? MinAge { get; set; }

        [JsonPropertyName("max-age")]
        public int? MaxAge { get; set; }

        //[JsonPropertyName("working-days")]
        //public List<DayViewDTO>? WorkingDays { get; set; }

        [JsonPropertyName("difficulty")]
        public Difficulty Difficulty { get; set; }

        //[JsonPropertyName("northern-latitude")]
        //public float? NorthernLatitude { get; set; }

        //[JsonPropertyName("eastern-latitude")]
        //public float? EasternLatitude { get; set; }
    }

    public class MereLandmarkViewModel
    {
        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("interests")]
        public List<Interest>? Interests { get; set; }
    }

}
