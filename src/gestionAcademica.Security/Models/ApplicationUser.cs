using Microsoft.AspNetCore.Identity;

namespace gestionAcademica.Security.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string Name { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
