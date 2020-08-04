using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.UI.Models
{
    //Classe abstrata -> não pode ser instanciada
    //pode conter métodos abstratos
    abstract class Veiculo
    {
        //Fields (Atributos)
        private string _nome;

        private decimal _valor;

        //Construtores
        public Veiculo(string nome)
        {
            _nome = nome;
        }

        //Propriedades (Gets/Sets)
        public string Marca{ get; set; }

        //prop -> tab tab
        public String Placa { get; set; }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        //Métodos
        public void Acelerar(double velocidade)
        {}

        public abstract void Parar();
    }
}
