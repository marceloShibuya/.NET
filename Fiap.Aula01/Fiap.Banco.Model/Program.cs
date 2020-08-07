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
            ContaCorrente cc = new ContaCorrente(111,DateTime.Now,0001, (decimal)200.00);
            ContaPoupanca cp = new ContaPoupanca(222, DateTime.Now, 0002, (decimal)1000.00,5.00M);

            IList<ContaCorrente> lista = new List<ContaCorrente>();
            lista.Add(cc);
            lista.Add(new ContaCorrente(112, DateTime.Now, 0003, (decimal)100.00));
            lista.Add(new ContaCorrente(113, DateTime.Now, 0004, (decimal)300.00));

            foreach(ContaCorrente item in lista){
                Console.WriteLine(lista.saldo);
            }


           
        }
    }
}
