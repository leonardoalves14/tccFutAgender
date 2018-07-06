using SocietyAgendor.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyAgendor.API.Services
{
    public interface IHorarioRepository
    {
        List<Horario> GetAllHorarios();
        Horario CreateHorario(Horario model);
        void UpdateHorario(Horario model);
        void DeleteHorario(int horarioId);
    }
}
