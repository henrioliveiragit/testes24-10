using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

class Program12
{
    // Implementa um algoritmo de busca binária para encontrar um elemento específico em uma lista ordenada
    static int BuscaBinaria(int[] lista, int elemento)
    {
        // Define os limites inferior e superior da busca
        int inicio = 0;
        int fim = lista.Length - 1;

        // Repete o processo enquanto o limite inferior for menor ou igual ao superior
        while (inicio <= fim)
        {
            // Calcula o índice do meio da lista
            int meio = (inicio + fim) / 2;

            // Compara o elemento do meio com o elemento desejado
            if (lista[meio] == elemento)
            {
                // Retorna o índice do meio se for igual
                return meio;
            }
            else if (lista[meio] > elemento)
            {
                // Reduz o limite superior se for maior
                fim = meio - 1;
            }
            else
            {
                // Aumenta o limite inferior se for menor
                inicio = meio + 1;
            }
        }

        // Retorna -1 se não encontrar o elemento
        return -1;
    }

    // Implementa um algoritmo de ordenação rápida para ordenar uma lista de números inteiros
    static void OrdenacaoRapida(int[] lista, int inicio, int fim)
    {
        // Verifica se a lista tem mais de um elemento
        if (inicio < fim)
        {
            // Escolhe um elemento pivô da lista
            int pivo = lista[inicio];

            // Define os índices esquerdo e direito da lista
            int esquerdo = inicio + 1;
            int direito = fim;

            // Repete o processo enquanto os índices não se cruzarem
            while (esquerdo <= direito)
            {
                // Avança o índice esquerdo enquanto o elemento for menor ou igual ao pivô
                while (esquerdo <= direito && lista[esquerdo] <= pivo)
                {
                    esquerdo++;
                }

                // Recua o índice direito enquanto o elemento for maior que o pivô
                while (esquerdo <= direito && lista[direito] > pivo)
                {
                    direito--;
                }

                // Troca os elementos de posição se os índices não se cruzarem
                if (esquerdo < direito)
                {
                    int aux = lista[esquerdo];
                    lista[esquerdo] = lista[direito];
                    lista[direito] = aux;
                }
            }

            // Troca o pivô com o elemento do índice direito
            lista[inicio] = lista[direito];
            lista[direito] = pivo;

            // Chama a função recursivamente para as sub-listas à esquerda e à direita do pivô
            OrdenacaoRapida(lista, inicio, direito - 1);
            OrdenacaoRapida(lista, direito + 1, fim);
        }
    }

    // Implementa um servidor web simples que retorne uma página HTML com uma lista de números aleatórios
    static void ServidorWeb()
    {
        // Cria um objeto do tipo HttpListener para escutar as requisições HTTP na porta 8080
        HttpListener servidor = new HttpListener();
        servidor.Prefixes.Add("http://localhost:8080/");
        servidor.Start();

        Console.WriteLine("Servidor web iniciado na porta 8080");

        // Entra em um loop infinito para atender as requisições
        while (true)
        {
            // Aguarda uma requisição e obtém o contexto da mesma
            HttpListenerContext contexto = servidor.GetContext();

            // Obtém a resposta da requisição e define o tipo de conteúdo como HTML
            HttpListenerResponse resposta = contexto.Response;
            resposta.ContentType = "text/html";

            // Cria um objeto do tipo Random para gerar números aleatórios
            Random random = new Random();

            // Cria uma lista de números aleatórios entre 1 e 100 com 10 elementos
            List<int> numeros = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                numeros.Add(random.Next(1, 101));
            }

            // Cria uma string com o código HTML da página, contendo a lista de números em uma tabela
            string html = "<html><head><title>Servidor Web</title></head><body><h1>Servidor Web</h1><p>Lista em C#</p><p>Abaixo esta uma lista de numeros aleatorios entre 1 e 100:</p><table border='1'><tr>";
            foreach (int numero in numeros)
            {
                html += "<td>" + numero + "</td>";
            }
            html += "</tr></table></body></html>";

            // Converte a string HTML em um array de bytes
            byte[] buffer = Encoding.UTF8.GetBytes(html);

            // Define o tamanho do conteúdo da resposta como o tamanho do array de bytes
            resposta.ContentLength64 = buffer.Length;

            // Obtém o stream de saída da resposta e escreve o array de bytes no mesmo
            Stream saida = resposta.OutputStream;
            saida.Write(buffer, 0, buffer.Length);

            // Fecha o stream e a resposta
            saida.Close();
            resposta.Close();
        }
    }

    static void Main(string[] args)
    {
        // Testa a função de busca binária com uma lista ordenada e um elemento específico
        int[] lista = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        int elemento = 50;
        int indice = BuscaBinaria(lista, elemento);
        Console.WriteLine("O índice do elemento {0} na lista é {1}", elemento, indice);

        // Testa a função de ordenação rápida com uma lista desordenada
        int[] lista2 = { 25, 17, 43, 91, 6, 78, 34, 55, 12, 49 };
        Console.WriteLine("A lista antes da ordenação é:");
        foreach (int numero in lista2)
        {
            Console.Write(numero + " ");
        }
        Console.WriteLine();
        OrdenacaoRapida(lista2, 0, lista2.Length - 1);
        Console.WriteLine("A lista depois da ordenação é:");
        foreach (int numero in lista2)
        {
            Console.Write(numero + " ");
        }
        Console.WriteLine();

        // Inicia o servidor web simples
        ServidorWeb();
    }
}