using System.Collections.Generic;
using FutAgender.API.Models;
using FutAgender.RepositoryApp.Abastract;
using Microsoft.AspNetCore.Mvc;

namespace FutAgender.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ValuesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult GetClientes()
        {
            var result = new List<ClienteModel>();
            var list = _clienteRepository.GetClientes();


            foreach (var item in list)
            {
                var cliente = new ClienteModel
                {
                    Id = item.ClienteId,
                    Nome = item.ClienteNome,
                    CPF = item.ClienteCPF,
                    RG = item.ClienteRG,
                    Email = item.ClienteEmail,
                    DtNascimento = item.ClienteDtNascimento,
                    Telefone = item.ClienteTelefone,
                    Celular = item.ClienteCelular,
                    Endereco_Id = item.EnderecoId,
                    Logradouro = item.EnderecoLogradouro,
                    Numero = item.EnderecoNumero,
                    Cidade = item.EnderecoCidade,
                    Estado = item.EnderecoEstado,
                    Complemento = item.EnderecoComplemento,
                    CEP = item.EnderecoCEP
                };
                result.Add(cliente);
            }

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
