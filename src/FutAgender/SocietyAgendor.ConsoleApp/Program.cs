using System;
using FutAgender.RepositoryApp.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyAgendor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IClienteRepository clienteRepository;

            
            Console.ReadKey();
        }
        
        public static async Task<List<Cliente>> ListClientes(IClienteRepository _clienteRepository)
        {
            var result = new List<Cliente>();

            var clientes = await _clienteRepository.GetClientes();
            foreach (var item in clientes)
            {
                result.Add(new Cliente
                {
                    Id = item.ClienteId,
                    Nome = item.ClienteNome,
                    CPF = item.ClienteCPF,
                    RG = item.ClienteRG,
                    Email = item.ClienteEmail,
                    DtNascimento = item.ClienteDtNascimento,
                    Telefone = item.ClienteTelefone,
                    Celular = item.ClienteCelular,
                    EnderecoId = item.EnderecoId,
                    Logradouro = item.EnderecoLogradouro,
                    Numero = item.EnderecoNumero,
                    Bairro = item.EnderecoBairro,
                    Complemento = item.EnderecoComplemento,
                    Cidade = item.EnderecoCidade,
                    Estado = item.EnderecoEstado,
                    CEP = item.EnderecoCEP
                });
            }

            return result;
        }
    }
}
