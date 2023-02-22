using System.Text.Json.Serialization;

namespace tpa_backend.DTOModels
{
    public class UserViewDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("tourists")]
        public List<TouristViewDTO> Tourists { get; set; }

        [JsonPropertyName("plans")]
        public List<PlanViewDTO> Plans { get; set; }
    }

    public class UserCreateEditDTO
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
