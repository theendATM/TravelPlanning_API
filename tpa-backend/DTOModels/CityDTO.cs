using System.Text.Json.Serialization;

namespace tpa_backend.DTOModels
{
    public class CityViewDTO
    {
        //[JsonPropertyName("id")]
        //public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("landmarks")]
        public IEnumerable<LandmarkViewDTO>? Landmarks { get; set; }
    }
}
