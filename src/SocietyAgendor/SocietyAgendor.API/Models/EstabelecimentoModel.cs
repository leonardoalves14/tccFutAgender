﻿using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.API.Models
{
    public class EstabelecimentoModel
    {
        public int? Estabelecimento_Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        public string Estabelecimento_Nome { get; set; }

        [Required]
        public string Estabelecimento_CNPJ { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "É permitido até 20 caracteres.")]
        public string Estabelecimento_Celular { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        public string Estabelecimento_Email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "É permitido até 20 caracteres.")]
        public string Estabelecimento_Telefone { get; set; }

        public int? Endereco_Id { get; set; }

        [Required]
        public string Endereco_Numero { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Endereco_Logradouro { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Endereco_Bairro { get; set; }
                
        [MaxLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Complemento { get; set; }

        [Required]
        public string Endereco_CEP { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Cidade { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "É permitido até 2 caracteres.")]
        public string Endereco_Estado { get; set; }
    }
}
