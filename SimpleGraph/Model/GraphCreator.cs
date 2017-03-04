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

        public static Graph CreateRandomGraph(/*int l, int p */)
        {
            //TODO
            return new Graph();
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
