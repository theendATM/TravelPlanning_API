﻿using System.ComponentModel.DataAnnotations;

namespace tpa_backend.Models
{
    public class Tourist
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(3)]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public IEnumerable<Interest>? Interests { get; set; }

        public User User { get; set; }
    }
}
