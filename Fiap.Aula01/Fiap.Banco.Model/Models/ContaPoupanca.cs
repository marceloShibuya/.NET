using Fiap.Banco.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Banco.Model
{
    class ContaPoupanca : Conta, IContaInvestimento
    {
        //Propriedade 
        public decimal Taxa { get; set; }

        //Field
        //readonly -> só podemos adicionar valor na declaração ou no construtor 
        private readonly decimal _rendimento;

        //Construtor - ctor -> tab tab
        public ContaPoupanca( decimal rendimento) 
        {
            this._rendimento = rendimento;
        }

        public decimal CalculaRetornoInvestimento()
        {
            return Saldo *= _rendimento;
        }

        public override void Retirar(decimal valor)
        {
            if(Saldo >= valor + Taxa)
            {
                Saldo -= (valor + Taxa);
            }
            else
            {
                throw new SaldoInsuficienteException("Saldo insuficiente");
            }  
        }

    }
}
