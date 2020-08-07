using Fiap.Banco.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Banco.Model
{
    class ContaCorrente : Conta 
    {
        public TipoConta tipo { get; set; }

        public ContaCorrente(int agencia, DateTime dataAbertura, int numero, decimal saldo) 
        {
            
        }
        

        public override void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public override void Retirar(decimal valor)
        {
            if(tipo == TipoConta.Comum && Saldo < valor)
            {
                throw new SaldoInsuficienteException("Saque não permitido");
            }
            else
            {
                Saldo -= valor;
            }
        }
    }
}
