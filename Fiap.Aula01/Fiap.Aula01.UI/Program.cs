using Fiap.Aula01.UI.Exceptions;
using Fiap.Aula01.UI.Models;
using System;
using System.Collections;
using System.Collections.Generic;

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
            carro.Nome = "Gol";

            carro.Combustivel = Combustivel.Flex;


            //Exibir o nome do carro
            Console.WriteLine(carro.Nome);

            //Criar uma lista de motos
            IList<Moto> lista = new List<Moto>();

            //Adicionar duas motos na lista
            lista.Add(new Moto("Honda"));

            Moto moto = new Moto("Yamaha");
            lista.Add(moto);

            //Foreach para percorrer todos os elementos da lista
            //foreach(var item in lista){}
            foreach (Moto item in lista)
            {
                Console.WriteLine(item.Nome);
            }

            try
            {
                carro.Acelerar(-100);
            }catch (VelocidadeInvalidaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

         
        }

    }
}
