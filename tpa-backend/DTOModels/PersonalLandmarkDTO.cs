using System.Text.Json.Serialization;

namespace tpa_backend.DTOModels
{
    public class PersonalLandmarkViewDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("visit-time")]
        public int VisitTime { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("obligitary-visit")]
        public bool? ObligitaryVisit { get; set; }
    }

    public class PersonalLandmarkCreateEditDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("visit-time")]
        public int VisitTime { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("obligitary-visit")]
        public bool? ObligitaryVisit { get; set; }
    }
}
