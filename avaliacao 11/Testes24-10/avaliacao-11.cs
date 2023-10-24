using System;
using System.IO;
using System.Linq;

namespace Testes24_10
{


class Program11
    {
        static void Main(string[] args)
        {
            // Lê um arquivo texto contendo uma lista de números inteiros
            string[] linhas = File.ReadAllLines("numeros.txt");

            // Converte as linhas em números inteiros
            int[] numeros = linhas.Select(int.Parse).ToArray();

            // Calcula a média dos números da lista
            double media = numeros.Average();

            // Imprime a média dos números da lista
            Console.WriteLine("A média dos números da lista é {0}", media);
        }
    }
}
