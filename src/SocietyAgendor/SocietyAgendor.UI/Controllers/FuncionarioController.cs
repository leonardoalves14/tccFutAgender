using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public async Task<IActionResult> Index()
        {
            var funcionarios = await _funcionarioService.GetFuncionariosAsync();

            return View(funcionarios);
        }

        public IActionResult FuncionarioAdd()
        {
            return PartialView("_NewFuncPartial", new FuncionarioModel());
        }

        [HttpPost]
        public async Task<IActionResult> FuncionarioAdd(FuncionarioModel funcionario)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var newFunc = await _funcionarioService.CreateFuncionarioAsync(funcionario);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> FuncionarioUpdate(int funcId)
        {
            var funcionarios = await _funcionarioService.GetFuncionariosAsync();
            var funcionario = funcionarios.Find(c => c.Funcionario_Id == funcId);

            return View("EditFuncionario", funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> FuncionarioUpdate(FuncionarioModel funcionario)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }
            
            // todo
            return null;
        }
    }
}