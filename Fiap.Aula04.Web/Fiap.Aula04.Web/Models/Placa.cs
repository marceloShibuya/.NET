using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Models
{
    [Table("Tbl_Placa")]
    public class Placa
    {
        [Column("Id")]
        public int PlacaId { get; set; }

        [Required, MaxLength(8), Display(Name = "Número da placa")]
        public string Numero { get; set; }

        [Required, MaxLength(2), Display(Name = "Estado da placa")]
        public string Estado { get; set; }


    }
}
