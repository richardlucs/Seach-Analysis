using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TP03_Pesquisa
{
    class Program
    {     
        static void Main(string[] args)
        { 
            int opc;

            //Implementação do Menu principal onde o usuário pode escolher que tipo de pesquisa fazer.
            do
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("= Análise de Pesquisa - Airbnb =");
                Console.WriteLine("================================");

                Console.WriteLine("\nTipos de Pesquisa:");
                Console.WriteLine("\n[1] Sequencial\n[2] Binária\n[3] Árvore\n[4] Tabela Hash\n[0] Sair");
                Console.Write("\nOpção: ");
                opc = int.Parse(Console.ReadLine());
                int RoomID;
                int NumComp = 0;

                //Ao escolher o tipo de pesquisa, é solicitado o RoomID e este é enviado para uma junção das funções Pesquisa Airbnb (que retorna um objeto do tipo Airbnb com os dados) e ImprimirAirbnb (que recebe o objeto e imprime os dados).
                switch (opc)
                { 
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Pesquisa Sequencial");
                        Console.WriteLine("-------------------");

                        Console.Write("\nRoomID: ");
                        RoomID = int.Parse(Console.ReadLine());

                        ImprimirAirbnb(PesquisaAirbnb(RoomID, NumComp, "Pesquisa Sequencial"));
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("----------------");
                        Console.WriteLine("Pesquisa Binária");
                        Console.WriteLine("----------------");

                        Console.Write("\nRoomID: ");
                        RoomID = int.Parse(Console.ReadLine());

                        ImprimirAirbnb(PesquisaAirbnb(RoomID, NumComp, "Pesquisa Binária"));
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Árvore Binária de Busca");
                        Console.WriteLine("-----------------------");

                        Console.Write("\nRoomID: ");
                        RoomID = int.Parse(Console.ReadLine());

                        ImprimirAirbnb(PesquisaAirbnb(RoomID, NumComp, "Árvore Binária de Busca"));
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("-----------");
                        Console.WriteLine("Tabela Hash");
                        Console.WriteLine("-----------");

                        Console.Write("\nRoomID: ");
                        RoomID = int.Parse(Console.ReadLine());

                        ImprimirAirbnb(PesquisaAirbnb(RoomID, NumComp, "Tabela Hash"));
                        Console.ReadKey();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            } while (opc != 0);

        }

        //O método Pesquisa Airbnb recebe como parâmetros o RoomID a ser pesquisado, o NumComp para computar as comparações e um string com o tipo de pesquisa;
        private static Airbnb PesquisaAirbnb(int RoomID, int NumComp, string TipoPesquisa)
        {
            //Instanciando a classe Pesquisa (que contém todos os métodos) e passando como parâmetro a Lista de dados extraídos do arquivo airbnb.txt;
            Pesquisa MinhasPesquisas = new Pesquisa(ExtrairDados("airbnb.txt"));
            //Zerando o número de comparações a cada vez que essa função é chamada;
            NumComp = 0;

            //As condições a seguir avaliam o string TipoPesquisa para exibir as estatísticas da pesquisa e chamar a função de busca referente a cada tipo;
            //Inicia um cronômetro para avaliar quanto tempo a função demora para retornar o objeto Airbnb;
            //Logo, mostra as estatísticas de tempo e número de comparações seguindo do retorno de dados se encontrar o RoomID, e caso não encontre mostra a mensagem "Airbnb não encontrado!".
            if(TipoPesquisa == "Pesquisa Sequencial")
            {
                Console.Clear();
                Console.Write("Pesquisando RoomID {0}...", RoomID);

                Stopwatch cron = Stopwatch.StartNew();
                Airbnb DadoAirbnb = MinhasPesquisas.PesquisaSequencial(RoomID, ref NumComp);
                cron.Stop();

                Console.Clear();
                Console.WriteLine("Pesquisa Concluída");
                Console.WriteLine("------------------");
                Console.WriteLine("\nRoomID pesquisado: {0}", RoomID);
                Console.WriteLine("Número de Comparações: {0}", NumComp);
                Console.WriteLine("Tempo: {0} ms\n", cron.ElapsedMilliseconds);
                Console.WriteLine("------------------");

                if (DadoAirbnb == null)
                {
                    Console.WriteLine("Airbnb não encontrado!");
                }
                else
                {
                    return DadoAirbnb;
                }
            }
            else if(TipoPesquisa == "Pesquisa Binária")
            {
                Console.Clear();
                Console.Write("Pesquisando RoomID {0}...", RoomID);

                Stopwatch cron = Stopwatch.StartNew();
                Airbnb DadoAirbnb = MinhasPesquisas.PesquisaBinária(RoomID, ref NumComp);
                cron.Stop();

                Console.Clear();
                Console.WriteLine("Pesquisa Concluída");
                Console.WriteLine("------------------");
                Console.WriteLine("\nRoomID pesquisado: {0}", RoomID);
                Console.WriteLine("Número de Comparações: {0}", NumComp);
                Console.WriteLine("Tempo: {0} ms\n", cron.ElapsedMilliseconds);
                Console.WriteLine("------------------");

                if (DadoAirbnb == null)
                {
                    Console.WriteLine("Airbnb não encontrado!");
                }
                else
                {
                    return DadoAirbnb;
                }
            }
            else if (TipoPesquisa == "Árvore Binária de Busca")
            {
                Console.Clear();
                Console.Write("Pesquisando RoomID {0}...", RoomID);

                Stopwatch cron = Stopwatch.StartNew();
                Airbnb DadoAirbnb = MinhasPesquisas.Árvore(RoomID, ref NumComp);
                cron.Stop();

                Console.Clear();
                Console.WriteLine("Pesquisa Concluída");
                Console.WriteLine("------------------");
                Console.WriteLine("\nRoomID pesquisado: {0}", RoomID);
                Console.WriteLine("Número de Comparações: {0}", NumComp);
                Console.WriteLine("Tempo: {0} ms\n", cron.ElapsedMilliseconds);
                Console.WriteLine("------------------");

                if (DadoAirbnb == null)
                {
                    Console.WriteLine("Airbnb não encontrado!");
                }
                else
                {
                    return DadoAirbnb;
                }
            }
            else if (TipoPesquisa == "Tabela Hash")
            {
                Console.Clear();
                Console.Write("Pesquisando RoomID {0}...", RoomID);

                Stopwatch cron = Stopwatch.StartNew();
                Airbnb DadoAirbnb = MinhasPesquisas.TabelaHash(RoomID, ref NumComp);
                cron.Stop();

                Console.Clear();
                Console.WriteLine("Pesquisa Concluída");
                Console.WriteLine("------------------");
                Console.WriteLine("\nRoomID pesquisado: {0}", RoomID);
                Console.WriteLine("Número de Comparações: {0}", NumComp);
                Console.WriteLine("Tempo: {0} ms\n", cron.ElapsedMilliseconds);
                Console.WriteLine("------------------");

                if (DadoAirbnb == null)
                {
                    Console.WriteLine("Airbnb não encontrado!");
                }
                else
                {
                    return DadoAirbnb;
                }
            }

            return null;
        }

        //O método ExtrairDados recebe como parâmetro o nome do arquivo e retorna um List contendo todos os dados lidos.
        private static List<Airbnb> ExtrairDados(string Arq)
        {
            List<Airbnb> ListaAirbnb = new List<Airbnb>();
            string[] Linhas = File.ReadAllLines(Arq).Skip(1).ToArray();

            foreach(string Linha in Linhas)
            {
                string[] Dados = Linha.Split('\t');

                ListaAirbnb.Add(
                    new Airbnb(int.Parse(Dados[0]),
                               int.Parse(Dados[1]),
                               Dados[2],
                               Dados[3],
                               Dados[4],
                               Dados[5],
                               double.Parse(Dados[6]),
                               double.Parse(Dados[7], CultureInfo.InvariantCulture),
                               int.Parse(Dados[8]),
                               double.Parse(Dados[9], CultureInfo.InvariantCulture),
                               double.Parse(Dados[10], CultureInfo.InvariantCulture),
                               Dados[11])
                    { }
                );
            }

            return ListaAirbnb;
        }

        //O método ImprimirAirbnb recebe o objeto de dados, verifica se ele não é nulo e, caso não for, mostra linha a linha o dado Airbnb obtido.
        private static void ImprimirAirbnb(Airbnb Dado)
        {
            if (Dado != null)
            {
                Console.WriteLine(
                     "\nRoomID: {0}\n" +
                     "HostID: {1}\n" +
                     "Room Type: {2}\n" +
                     "Country: {3}\n" +
                     "City: {4}\n" +
                     "Neighborhood: {5}\n" +
                     "Reviews: {6}\n" +
                     "Overall Satisfaction: {7:0.0}\n" +
                     "Accommodates: {8}\n" +
                     "Bedrooms: {9:0.0}\n" +
                     "Price: {10:0.0}\n" +
                     "Property Type: {11}",
                     Dado.RoomID,
                     Dado.HostID,
                     Dado.RoomType,
                     Dado.Country,
                     Dado.City,
                     Dado.Neighborhood,
                     Dado.Reviews,
                     Dado.OverallSatisfaction,
                     Dado.Accommodates,
                     Dado.Bedrooms,
                     Dado.Price,
                     Dado.PropertyType
                 );
            }  
        }
    }
}
