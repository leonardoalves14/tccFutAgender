using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyAgendor.API.Concrete
{
    public class HorarioRepository : Base.Base, IHorarioRepository
    {
        public HorarioRepository(IConfiguration configuration) : base(configuration) { }

        public List<Horario> GetAllHorarios()
        {
            throw new NotImplementedException();
        }

        public Horario CreateHorario(Horario model)
        {
            throw new NotImplementedException();
        }

        public void UpdateHorario(Horario model)
        {
            throw new NotImplementedException();
        }

        public void DeleteHorario(int horarioId)
        {
            throw new NotImplementedException();
        }
    }
}
