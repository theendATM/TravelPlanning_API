using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using tpa_backend.Models;

namespace tpa_backend.DTOModels
{
    public class PlanViewDTO
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
        public float? PlanDifficulty { get; set; }

        [JsonPropertyName("exit-time")]
        public DateTime? ExitTime { get; set; }

        [JsonPropertyName("coming-time")]
        public DateTime? ComingTime { get; set; }

        [JsonPropertyName("moving-types")]
        public List<MovingType>? MovingTypes { get; set; }

        [JsonPropertyName("days")]
        public List<Day>? Days { get; set; }

    }

    public class PlanCreateDTO
    {
        //1
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("budget")]
        public int? Budget { get; set; }


        [JsonPropertyName("tourist-ids")]
        public List<Guid>? TouristIds { get; set; }

        [JsonPropertyName("difficulty-ids")]
        public int[]? DifficultyIds { get; set; }

        //3

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("arrival-time")]
        public DateTime? ArrivalTime { get; set; }

        [JsonPropertyName("departure-time")]
        public DateTime? DepartureTime { get; set; }

        [JsonPropertyName("moving-types-ids")]
        public int[]? MovingTypeIds { get; set; }

        [JsonPropertyName("exit-time")]
        public DateTime? ExitTime { get; set; }

        [JsonPropertyName("coming-time")]
        public DateTime? ComingTime { get; set; }

        //2
        [JsonPropertyName("landmarks-ids")]
        public int[]? LandmarkIds { get; set; }

    }


    public class PlanEditDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }



    }
