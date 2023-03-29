using System.Text.Json.Serialization;

namespace tpa_backend.DTOModels
{
    public class MovingTypeViewDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
