using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Landmark>? Landmarks { get; set; }
    
        public IEnumerable<Tourist>? Tourists { get; set; }
    }
}
