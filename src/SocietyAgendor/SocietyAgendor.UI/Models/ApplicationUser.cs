using Microsoft.AspNetCore.Identity;

namespace SocietyAgendor.UI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
    }
}
