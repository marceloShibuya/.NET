using Fiap.Aula04.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.ViewModels
{
    public class ClienteTestDriveModel
    {
        public Cliente Cliente { get; set; }

        public List<Veiculo> Veiculos { get; set; }

        public SelectList VeiculosTestDrive { get; set; }
        
    }
}
