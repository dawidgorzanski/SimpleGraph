using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraph.Model
{
    public static class GraphCreator
    {

        public static Graph CreateFromMatrix(int[,] MatrixInt)
        {
            int Dimension = MatrixInt.GetLength(0);
            Graph fromMatrix = new Graph();

            for (int i = 0; i < Dimension; i++)
                fromMatrix.Nodes.Add(new Node() { ID = i });
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = i + 1; j < Dimension; j++)
                {
                    if (MatrixInt[i, j] == 1)
                    {
                        fromMatrix.Connections.Add(new Connection { Node1 = fromMatrix.Nodes[i], Node2 = fromMatrix.Nodes[j] });
                    }
                }
            }
            return fromMatrix;
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

        public static Graph CreateRandomGraphProbability(int Nodes, double Probability) // G(n, p)
        {
            Graph randomGraph = new Graph();
            for (int i = 0; i < Nodes; i++)
                randomGraph.Nodes.Add(new Node() { ID = i });
            Random rnd = new Random();
            double currentProbability;
            for (int i = 0; i < Nodes; i++)
            {
                for (int j = i+1; j < Nodes; j++)
                {
                    currentProbability = rnd.NextDouble();
                    if (currentProbability < Probability)
                    {
                        Connection connection = new Connection();
                        connection.Node1 = randomGraph.Nodes.FirstOrDefault(x => x.ID == i);
                        connection.Node2 = randomGraph.Nodes.FirstOrDefault(x => x.ID == j);
                        randomGraph.Connections.Add(connection);
                    }
                }
            }
            return randomGraph;
        }

        public static Graph CreateRandomGraph(int Nodes, int Connections)
        {
            int maxConnections = Graph.MaxConnections(Nodes);
            Random rnd = new Random();

            if (Connections > maxConnections)
            {
                //Tutaj wypisywanie bledu
                //TODO
                return new Graph();
            }

            //Przypadek gdy polaczen do zrealizowania jest mniej niz maksymalna liczba polaczen
            if (maxConnections - Connections >= Connections)
            {
                Graph randomGraph = new Graph();

                for (int i = 0; i < Nodes; i++)
                    randomGraph.Nodes.Add(new Node() { ID = i });
                while (Connections > 0)
                {
                    int n1 = rnd.Next(0, Nodes);
                    int n2 = rnd.Next(0, Nodes);
                    if (n1 == n2)
                        continue;
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
                return randomGraph;
            }
            else //A tutaj ten drugi przypadek
            {
                Graph randomGraph = CreateFullGraph(Nodes);

                int toDelConnections = maxConnections - Connections;

                Connection removeCompare = randomGraph.Connections.Find(x => x.Node1 == randomGraph.Nodes.Find(y => y.ID == Nodes));
                while (toDelConnections > 0)
                {
                    int n1 = rnd.Next(0, Nodes);
                    int n2 = rnd.Next(0, Nodes);
                    if (n1 == n2)
                        continue;
                    Connection remove1 = randomGraph.Connections.Find(x => x.Node1 == randomGraph.Nodes.Find(y => y.ID == n1) && x.Node2 == randomGraph.Nodes.Find(y => y.ID == n2));
                    Connection remove2 = randomGraph.Connections.Find(x => x.Node2 == randomGraph.Nodes.Find(y => y.ID == n1) && x.Node1 == randomGraph.Nodes.Find(y => y.ID == n2));
                    if (remove1 == removeCompare && remove2 == removeCompare)
                        continue;
                    if (remove1 != removeCompare)
                        randomGraph.Connections.Remove(remove1);
                    else
                        randomGraph.Connections.Remove(remove2);

                    toDelConnections--;
                }

                return randomGraph;
            }
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
                for (int j = i+1; j < Nodes; j++)
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

            return fullGraph;
        }
    }
}
