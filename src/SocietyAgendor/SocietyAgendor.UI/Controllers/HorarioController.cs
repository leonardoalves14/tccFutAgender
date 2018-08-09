using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SocietyAgendor.UI.Controllers
{
    public class HorarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}