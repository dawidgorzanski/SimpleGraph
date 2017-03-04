using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraph.Model
{
    public static class GraphCreator
    {

        public static Graph CreateFromMatrix(string Matrix)
        {
            //TODO
            return new Graph();
        }

        public static Graph CreateFromList(string List)
        {
            //TODO
            return new Graph();
        }

        public static Graph CreateFromIncidenceMatrix(string IncidenceMatrix)
        {
            //TODO
            return new Graph();
        }

        public static Graph CreateRandomGraph(int Nodes, int Connections)
        {
            Graph randomGraph = new Graph();

            for (int i = 0; i < Nodes; i++)
                randomGraph.Nodes.Add(new Node() { ID = i });


            int maxConnections = Nodes * (Nodes - 1) / 2;
            Random rnd = new Random();

            //Przypadek gdy polaczen do zrealizowania jest mniej niz maksymalna liczba polaczen
            if (maxConnections - Connections > Connections)
            {
                while (Connections > 0)
                {
                    int n1 = rnd.Next(0, Nodes);
                    int n2 = rnd.Next(0, Nodes);
                    if (n1 == n2) continue;
                    if (randomGraph.Connections.Exists(x => x.Node1 == randomGraph.Nodes.Find(y => y.ID == n1) && x.Node2 == randomGraph.Nodes.Find(y => y.ID == n2)))
                        continue;
                    if (randomGraph.Connections.Exists(x => x.Node2 == randomGraph.Nodes.Find(y => y.ID == n1) && x.Node1 == randomGraph.Nodes.Find(y => y.ID == n2)))
                        continue;

                    Connection connection = new Connection();
                    connection.Node1 = randomGraph.Nodes.FirstOrDefault(x => x.ID == n1);
                    connection.Node2 = randomGraph.Nodes.FirstOrDefault(x => x.ID == n2);
                    randomGraph.Connections.Add(connection);

                    Connections--;
                }
            }

            return randomGraph;
        }

        //Zerknijcie na tworzenie połączeń :D
        public static Graph CreateFullGraph(int Nodes = 0)
        {
            Graph fullGraph = new Graph();

            //Dodanie wierzchołków
            for (int i = 0; i < Nodes; i++)
                fullGraph.Nodes.Add(new Node() { ID = i });

            //Dodanie połączeń między wierzchołkami
            for (int i = 0; i < Nodes; i++)
            {
                for (int j = 0; j < Nodes; j++)
                {
                    if (i != j)
                    {
                        Connection connection = new Connection();
                        //Nie tworzymy nowych obiektów typu Node, tylko wyszukujemy w Nodes już istniejące - znacznie ułatwia
                        //to rysowanie grafu - każdy obiekt Node dostaje później swoje współrzędne, ktore w obu listach są takie same.
                        //Jeżeli utworzylibyśmy nowy obiekt to po dodaniu współrzędnych obiektom w Nodes, w Connection nie
                        //zostałyby one zmienione.
                        //(x => x.ID == i) jest to tzw. wyrażenie Lambda - w tym wypadku szukamy pierwszego elementu o ID równym i.
                        connection.Node1 = fullGraph.Nodes.FirstOrDefault(x => x.ID == i);
                        connection.Node2 = fullGraph.Nodes.FirstOrDefault(x => x.ID == j);
                        fullGraph.Connections.Add(connection);
                    }
                }
            }          

            return fullGraph;
        }
    }
}
