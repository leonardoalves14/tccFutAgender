using System;

namespace FutAgender.API.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int Endereco_Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
    }
}
