using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Models
{
    [Table("Tbl_Veiculo")]
    public class Veiculo
    {
        //Nome da classe + Id : chave primária não precisa da anotação [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Column("Dt_Fabricacao")]
        public DateTime DataFabricacao { get; set; }

        public bool Novo { get; set; }

        public Combustivel Combustivel { get; set; }

    }
}
