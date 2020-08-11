using Fiap.Banco.Model.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Fiap.Banco.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente cc = new ContaCorrente()
            {
                Agencia = 1,
                Numero = 123,
                DataAbertura = new DateTime(2020,1,1),
                Saldo = 100,
                Tipo = TipoConta.Comum
            };

            ContaPoupanca cp = new ContaPoupanca(0.003m)
            {
                Agencia = 1,
                Numero = 321,
                DataAbertura = DateTime.Now,
                Saldo = 30,
                Taxa = 1
            };

            //Chamar o método retirar tratando o possível exception
            try
            {
                cc.Retirar(1000);
            }catch(SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
            }

            //Criar uma lista de conta poupança
            IList<ContaPoupanca> lista = new List<ContaPoupanca>();
            lista.Add(cp);
            lista.Add(new ContaPoupanca(0.003m) { Agencia = 2, Saldo = 100 });
            lista.Add(new ContaPoupanca(0.003m) { Saldo = 400 });


            foreach (ContaPoupanca item in lista)
            {
                Console.WriteLine("Saldo: " + item.Saldo);
                Console.WriteLine("Retorno: " + item.CalculaRetornoInvestimento());
                Console.WriteLine("Agencia: " + item.Agencia);
            }






        }
    }
}
