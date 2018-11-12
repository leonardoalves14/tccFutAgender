using SocietyAgendor.API.Entities;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface IAgendamentoRepository
    {
        List<Agendamento> GetAllAgendamentos();
        Agendamento CreateAgendamento(Agendamento model);
        void UpdateCargo(Agendamento model);
        void DeleteAgendamento(int agendamentoId);
    }
}
