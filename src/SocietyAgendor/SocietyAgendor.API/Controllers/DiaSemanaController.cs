using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;

namespace SocietyAgendor.API.Controllers
{
    [Route("api/diassemana")]
    public class DiaSemanaController : Controller
    {
        private readonly IDiaSemanaRepository _diaSemanaRepository;

        public DiaSemanaController(IDiaSemanaRepository diaSemanaRepository)
        {
            _diaSemanaRepository = diaSemanaRepository;
        }

        [HttpGet]
        public IActionResult GetAllDiasSemana()
        {
            var result = new List<DiaSemana>();
            var list = _diaSemanaRepository.GetAllDiasDaSemana();

            foreach (var item in list)
            {
                result.Add(new DiaSemana
                {
                    DiaSemana_Id = item.DiaSemana_Id,
                    DiaSemana_Desc = item.DiaSemana_Desc
                });
            }

            return Ok(result);
        }
    }
}