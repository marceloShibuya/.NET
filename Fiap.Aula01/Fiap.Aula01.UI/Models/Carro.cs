using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Fiap.Aula01.UI.Models
{
    class Carro : Veiculo
    {
        //Propriedades (Gets/Sets)
        public float CapacidadePortaMala { get; set; }

        public int QtdPortas { get; set; }

        //Construtor com nome e capacidade
        public Carro(string nome,float capacidade) :base(nome)
        {
            CapacidadePortaMala = capacidade;
        }
    }
}
