using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class Difficulty
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Landmark>? Landmarks { get; set; }

    }
}
