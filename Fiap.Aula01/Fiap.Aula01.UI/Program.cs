using Fiap.Aula01.UI.Models;
using System;

namespace Fiap.Aula01.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instanciar o carro
            Carro carro = new Carro("Golf", 1000)
            {
                Placa = "ABC-1234"
            };

            //Atribuir um nome para o carro
            carro.Nome = "Gol"

            //Exibir o nome do carro
            Console.WriteLine(carro.Nome);
        }

    }
}
