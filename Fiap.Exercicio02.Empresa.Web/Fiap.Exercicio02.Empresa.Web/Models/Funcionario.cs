using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.Models
{
    [Table("Tbl_Funcionario")]
    public class Funcionario
    {
        [Column("Id"), HiddenInput]
        public int FuncionarioId { get; set; }

        public Instituicao Instituicao { get; set; }

        public int InstituicaoId { get; set; }

        [MaxLength(50), Required]
        public String Nome { get; set; }

        [Display(Name = "Data Nascimento"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        public Cargo Cargo { get; set; }
    }
}
