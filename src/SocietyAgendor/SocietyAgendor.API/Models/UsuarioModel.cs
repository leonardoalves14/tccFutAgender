using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.API.Models
{
    public class UsuarioModel
    {
        public int? Usuario_Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Usuario_Login { get; set; }

        [StringLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        public string Usuario_Senha { get; set; }
    }
}
