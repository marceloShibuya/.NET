﻿using Microsoft.AspNetCore.Mvc;
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
        //Nome da classe + Id: chave primária, não preicsa da anotação [Key]
        [Column("Id"),HiddenInput]
        public int VeiculoId { get; set; }

        [Required, MaxLength(50)]
        public string Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Display(Name = "Data de Fabricação"), DataType(DataType.Date), Column("Dt_Fabricacao")]    
        public DateTime DataFabricacao { get; set; }

        public bool Novo { get; set; }

        [Display(Name = "Combustível")]
        public Combustivel Combustivel { get; set; }


    }
}