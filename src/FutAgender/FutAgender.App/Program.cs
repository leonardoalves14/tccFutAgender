using FutAgender.RepositoryApp.Concrete;
using System;
using System.Collections.Generic;

namespace FutAgender.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa Iniciado....");
            var result = GetClientes();
            Console.WriteLine("Finalizando....");
            Console.ReadKey();
        }

        public static List<Cliente> GetClientes()
        {
            var result = new List<Cliente>();
            ClienteRepository clienteRepository = new ClienteRepository();            

            var clientes = clienteRepository.GetClientes();
            foreach (var item in clientes)
            {
                result.Add(new Cliente
                {
                    Cliente_Id = item.ClienteId,
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
