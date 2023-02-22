using System.Text.Json.Serialization;

namespace tpa_backend.DTOModels
{
    public class InterestViewDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("landmarks")]
        public List<LandmarkViewDTO> Landmarks { get; set; }
    }
}
