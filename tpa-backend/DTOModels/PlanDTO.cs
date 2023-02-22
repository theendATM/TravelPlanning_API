using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using tpa_backend.Models;

namespace tpa_backend.DTOModels
{
    public class PlanViewDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("budget")]
        public int? Budget { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("arrival-time")]
        public DateTime? ArrivalTime { get; set; }

        [JsonPropertyName("departure-time")]
        public DateTime? DepartureTime { get; set; }

        [JsonPropertyName("difficulty")]
        public float? PlanDifficulty { get; set; }

        [JsonPropertyName("exit-time")]
        public TimeOnly? ExitTime { get; set; }

        [JsonPropertyName("coming-time")]
        public TimeOnly? ComingTime { get; set; }

        [JsonPropertyName("moving-types")]
        public List<MovingTypeViewDTO>? MovingTypes { get; set; }

        [JsonPropertyName("days")]
        public List<DayViewDTO>? Days { get; set; }

    }

    public class PlanCreateDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("budget")]
        public int? Budget { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("arrival-time")]
        public DateTime? ArrivalTime { get; set; }

        [JsonPropertyName("departure-time")]
        public DateTime? DepartureTime { get; set; }

        [JsonPropertyName("difficulty")]
        public List<DifficultyViewDTO>? Difficulty { get; set; }

        [JsonPropertyName("exit-time")]
        public DateTime? ExitTime { get; set; }

        [JsonPropertyName("coming-time")]
        public DateTime? ComingTime { get; set; }

        [JsonPropertyName("moving-types")]
        public List<MovingTypeViewDTO>? MovingTypes { get; set; }
    }

    public class PlanEditDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("budget")]
        public int? Budget { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("arrival-time")]
        public DateTime? ArrivalTime { get; set; }

        [JsonPropertyName("departure-time")]
        public DateTime? DepartureTime { get; set; }

        [JsonPropertyName("exit-time")]
        public DateTime? ExitTime { get; set; }

        [JsonPropertyName("coming-time")]
        public DateTime? ComingTime { get; set; }

        [JsonPropertyName("moving-types")]
        public List<MovingTypeViewDTO>? MovingTypes { get; set; }
    }

}
