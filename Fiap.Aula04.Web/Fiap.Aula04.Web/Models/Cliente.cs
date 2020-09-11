using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Models
{
    [Table("Tbl_Cliente")]
    public class Cliente
    {
        [Column("Id")]
        public int ClienteId { get; set; }

        [MaxLength(80), Required]
        public string Nome { get; set; }

        [Display(Name = "Data Nascimento"),DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public bool Pcd { get; set; }


    }
}
