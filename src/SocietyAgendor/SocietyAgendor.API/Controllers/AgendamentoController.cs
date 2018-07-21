using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System.Collections.Generic;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 AGENDAMENTO

    [Route("api/agendamentos")]
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoController(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        [HttpGet]
        public IActionResult GetAllAgendamentos()
        {
            var result = new List<AgendamentoModel>();
            var list = _agendamentoRepository.GetAllAgendamentos();

            foreach (var agendamento in list)
            {
                result.Add(new AgendamentoModel
                {
                    Agendamento_Id = agendamento.AgendamentoId,
                    Agendamento_Descricao = agendamento.AgendamentoDescricao,
                    Agendamento_Data = agendamento.AgendamentoData,
                    DiaSemana_Id = agendamento.DiaSemanaId,
                    DiaSemana_Desc = agendamento.DiaSemanaDesc,
                    Horario_Id = agendamento.HorarioId,
                    Horario_Desc = agendamento.HorarioDesc,
                    Cliente_Id = agendamento.ClienteId,
                    Cliente_Nome = agendamento.ClienteNome,
                    Estabelecimento_Id = agendamento.EstabelecimentoId,
                    Estabelecimento_Nome = agendamento.EstabelecimentoNome
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAgendamento([FromBody] AgendamentoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendamento = new Agendamento
            {
                AgendamentoDescricao = model.Agendamento_Descricao,
                ClienteId = model.Cliente_Id,
                EstabelecimentoId = model.Estabelecimento_Id,
                HorarioId = model.Horario_Id,
                DiaSemanaId = model.DiaSemana_Id
            };

            var newAgendamento = _agendamentoRepository.CreateAgendamento(agendamento);
            model.Agendamento_Id = newAgendamento.AgendamentoId;

            return Ok(model);
        }

        [HttpDelete("{agendamentoId}")]
        public IActionResult DeleteAgendamento(int agendamentoId)
        {
            _agendamentoRepository.DeleteAgendamento(agendamentoId);

            return NoContent();
        }
    }
}
