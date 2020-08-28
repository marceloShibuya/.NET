using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Models
{
    public class Vaga
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public bool Remoto { get; set; }
        public Regime Regime { get; set; }
        public string Empresa { get; set; } //Select com algumas opções


    }
}
