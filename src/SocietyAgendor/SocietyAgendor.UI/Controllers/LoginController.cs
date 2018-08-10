using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;

namespace SocietyAgendor.UI.Controllers
{
    public class LoginController: Controller
    {
        public IActionResult Index()
        {
            return View("LoginPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            // TODO: Fazer verificação usuário/senha
            if (!ModelState.IsValid)
            {
                throw new Exception("Login ou senha inválidos");
            }

            return RedirectToAction("Index", "Home", new { usuario = model.User });
        }
    }
}
