using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Models
{
    [Table("Tbl_Endereco")]
    public class Endereco
    {
        [Column("Id")]
        public int EnderecoId { get; set; }

        //Relacionamento muito para muito
        public IList<EnderecoCliente> EnderecoClientes { get; set; }

        [Required, MaxLength(80)]
        public string Logradouro { get; set; }

        public int Numero { get; set; }
    }
}
