using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.Models
{
    [Table("Tbl_Instituicao")]
    public class Instituicao
    {
        [Column("Id"), HiddenInput]
        public int InstituicaoId { get; set; }

        public IList<Funcionario> Funcionarios { get; set; }

        [MaxLength(50), Required(ErrorMessage = "o nome é obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "o cnpj é obrigatório"), MaxLength(20)]
        public String Cnpj { get; set; }

    }
}
