using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tpa_backend.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Landmark>? Landmarks { get; set; }
        [JsonIgnore]
        public IEnumerable<Plan>? Plans { get; set; }
    }
}
