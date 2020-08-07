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

        public void CalculaRetornoInvestimento()
        {
            throw new NotImplementedException();
        }

        public override void Depositar(decimal valor)
        {
            
        }

        public override void Retirar(decimal valor)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente");
        }
    }
}
