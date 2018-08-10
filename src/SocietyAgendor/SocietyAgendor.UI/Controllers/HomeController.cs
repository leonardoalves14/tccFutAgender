﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;

namespace SocietyAgendor.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string usuario)
        {
            ViewData["Login"] = usuario ?? "";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
