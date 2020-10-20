using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula05.API.Models
{
    [Table("Tbl_Cliente")]
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataNascimento { get; set; }


        //CRIAR UMA API PARA O CLIENTE

    }
}
