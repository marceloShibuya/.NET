using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula05.API.Models
{
    [Table("Tbl_Produto")]
    public class Produto
    {
        [Column("Id")]
        public int ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataFabricacao { get; set; }

        public string Fornecedor { get; set; }

    }
}
