using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();

            return View(usuarios);
        }

        [HttpPost]
        public IActionResult UsuarioUpdate(UsuarioModel usuario)
        {
            // todo
            return NoContent();
        }
    }
}