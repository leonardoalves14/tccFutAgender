using SocietyAgendor.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetUsuariosAsync();
    }
}
