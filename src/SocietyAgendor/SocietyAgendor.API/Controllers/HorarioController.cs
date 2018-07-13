using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System.Collections.Generic;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 HORÁRIO

    [Route("api/horarios")]
    public class HorarioController : Controller
    {
        private readonly IHorarioRepository _horarioRepository;

        public HorarioController(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        [HttpGet]
        public IActionResult GetAllHorarios()
        {
            var result = new List<HorarioModel>();
            var list = _horarioRepository.GetAllHorarios();

            foreach (var item in list)
            {
                result.Add(new HorarioModel
                {
                    Horario_Id = item.HorarioId,
                    Horario_De = item.HorarioDe,
                    Horario_Ate = item.HorarioAte,
                    DiaSemana_Id = item.DiaSemanaId,
                    DiaSemana_Desc = item.DiaSemanaDesc
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateHorario([FromBody] HorarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var horario = new Horario
            {
                HorarioDe = model.Horario_De,
                HorarioAte = model.Horario_Ate,
                DiaSemanaId = model.DiaSemana_Id
            };

            var newHorario = _horarioRepository.CreateHorario(horario);

            model.Horario_Id = newHorario.HorarioId;

            return Ok(model);
        }

        [HttpPut("{horarioId}")]
        public IActionResult UpdateHorario(int horarioId, [FromBody] HorarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            var horario = new Horario
            {
                HorarioId = model.Horario_Id,
                HorarioDe = model.Horario_De,
                HorarioAte = model.Horario_Ate,
                DiaSemanaId = model.DiaSemana_Id
            };

            _horarioRepository.UpdateHorario(horario);

            return NoContent();
        }

        [HttpDelete("{horarioId}")]
        public IActionResult DeleteHorario(int horarioId, [FromBody] HorarioModel model)
        {
            _horarioRepository.DeleteHorario((int)model.Horario_Id, (int)model.DiaSemana_Id);

            return NoContent();
        }
    }
}
