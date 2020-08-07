using Fiap.Aula01.UI.Exceptions;
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

        //Propriedades (Gets/Sets)
        //prop -> tab tab
        public string Marca { get; set; }

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


        //Construtores
        public Veiculo(string nome)
        {
            _nome = nome;
        }
       
        //Métodos
        //virtual -> permite a sobrescrita do método
        public virtual void Acelerar(double velocidade)
        {
            if(velocidade < 0)
            {
                throw new VelocidadeInvalidaException("Velocidade não pode ser negativa");
            }

            Console.WriteLine("Veículo acelerando" + velocidade);
        }

        //Sobrecarga de método
        public void Acelerar()
        {
            Console.WriteLine("Veículo acelerando");
        }

        public abstract void Parar();
    }
}
