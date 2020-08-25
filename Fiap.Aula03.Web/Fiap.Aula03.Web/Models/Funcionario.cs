using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Models
{
    public class Funcionario
    {
        [HiddenInput]
        public int Codigo { get; set; }

        public string Setor { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public Cargo Cargo { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Salário")]
        public decimal Salario { get; set; }
    }
}
