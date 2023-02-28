using System.Text.Json.Serialization;
using tpa_backend.Models;

namespace tpa_backend.DTOModels
{
    public class TouristViewDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("interests")]
        public List<Interest>? Interests { get; set; }
    }

    public class TouristCreateEditDTO
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("interests")]
        public List<Interest> Interests { get; set; }
    }

}
