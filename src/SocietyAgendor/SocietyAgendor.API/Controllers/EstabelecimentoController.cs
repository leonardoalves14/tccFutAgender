using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyAgendor.API.Controllers
{
    [Route("api/estabelecimentos")]
    public class EstabelecimentoController : Controller
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoController(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }
    }
}
