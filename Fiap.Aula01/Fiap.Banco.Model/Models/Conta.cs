using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Fiap.Banco.Model
{
    //classe abstrata -> não pode ser instanciada
    //pode conter métodos abstratos (sem implementação)
    //as classes filhas são obrigadas a implementar os métodos abstratos
    abstract class Conta
    {
        public int Agencia { get; set; }

        public DateTime DataAbertura { get; set; }

        public int Numero { get; set; }

        public decimal Saldo { get; set; }

        //virtual -> permite a sobrescrita do método
        public virtual void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public abstract void Retirar(decimal valor);

 
    }
}
