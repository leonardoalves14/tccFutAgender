using System;

namespace FutAgender.App
{
    public class Cliente
    {
        public int Cliente_Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
    }
}
