using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Models
{
    [Table("Tbl_Test_Drive")] //tabela associativa
    public class TestDrive
    {
        public int ClienteId { get; set; }

        public Cliente Cliente{ get; set; }

        public int VeiculoId { get; set; }

        public Veiculo Veiculo { get; set; }


    }
}
