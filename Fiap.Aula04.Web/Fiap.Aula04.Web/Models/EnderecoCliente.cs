using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Models
{
    public class EnderecoCliente
    {
        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

    }
}
