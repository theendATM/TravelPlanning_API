using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tpa_backend.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<Landmark>? Landmarks { get; set; }

        [JsonIgnore]
        public IEnumerable<Tourist>? Tourists { get; set; }
    }
}
