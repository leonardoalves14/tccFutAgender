using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}