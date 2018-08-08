using SocietyAgendor.UI.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetUsuariosAsync();
        Task<UsuarioModel> CreateUsuario(UsuarioModel model);
        Task<HttpStatusCode> DeleteUsuario(int usuarioId);
    }
}
