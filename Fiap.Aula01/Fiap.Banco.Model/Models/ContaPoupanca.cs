using Fiap.Banco.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Banco.Model
{
    class ContaPoupanca : Conta, IContaInvestimento
    {

        public decimal Taxa { get; set; }

        private readonly decimal _rendimento;

        public ContaPoupanca(decimal taxa, decimal rendimento) : this(taxa)
        {
            _rendimento = rendimento;
        }

        public ContaPoupanca(int agencia, DateTime dataAbertura, int numero, decimal saldo,decimal taxa) 
        {
            Taxa = Taxa;
        }

        public ContaPoupanca(decimal _rendimento)
        {
            _rendimento = (decimal)0.010;
        }

        public void CalculaRetornoInvestimento()
        {
            Saldo *= _rendimento;
        }

        public override void Depositar(decimal valor)
        {
            Saldo += valor;
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
