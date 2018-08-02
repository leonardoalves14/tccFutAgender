using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class UsuarioModel
    {
        public int? Usuario_Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Usuario_Login { get; set; }

        [MaxLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Usuario_Senha { get; set; }
    }
}
