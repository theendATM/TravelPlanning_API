using Microsoft.AspNetCore.Identity;

namespace tpa_backend.Models
{
    public class Role : IdentityRole
    {
        public string RoleName { get; set; }
        public string Description { get; set; }

    }
           
}
