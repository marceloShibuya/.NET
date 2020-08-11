using Fiap.Banco.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Banco.Model
{
    //alt + enter -> possíveis soluções para o problema
    //sealed -> classe que não pode ser herdada
    sealed class ContaCorrente : Conta 
    {
        //Atributo
        public TipoConta Tipo{ get; set; }


        public override void Retirar(decimal valor)
        {
            if(Tipo == TipoConta.Comum && Saldo < valor)
            {
                throw new SaldoInsuficienteException("Saque não permitido");
            }
            else // não é necessário o else pois quando lança a exceção já vai sair do método
            {
                Saldo -= valor;
            }
        }
    }
}
