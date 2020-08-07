using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Fiap.Aula01.UI.Models
{
    class Carro : Veiculo, ICompeticao
    {

        //Propriedades (Gets/Sets)
        public float CapacidadePortaMala { get; set; }

        public int QtdPortas { get; set; }

        public Combustivel Combustivel { get; set; }

        //Construtor com nome e capacidade
        public Carro(string nome,float capacidade) :base(nome)
        {
            CapacidadePortaMala = capacidade;
        }

        public override void Parar()
        {
            //cw -> tab tab
            Console.WriteLine("Carro parando...");
        }

        //sobrescrita do método Acelerar do veículo
        public override void Acelerar(double velocidade)
        {
            base.Acelerar(velocidade);
            Console.WriteLine("Carro acelerando");
        }

        public void Largar()
        {
            Console.WriteLine("Carro em modo de largada");
        }

        public void Arrancar()
        {
            Console.WriteLine("Carro arrancando com tudo");
        }
    }
}
