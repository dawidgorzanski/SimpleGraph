using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraph.Model
{
    public class Graph
    {
        private List<Node> _nodes;
        private List<Connection> _connections;

        public List<Node> Nodes
        {
            get
            {
                return _nodes;
            }
        }
        public List<Connection> Connections
        {
            get
            {
                return _connections;
            }
        }

        public Graph()
        {
            InitializeLists();
        }

        //Inicjalizuje listy _nodes oraz _connections
        private void InitializeLists()
        {
            _connections = new List<Connection>();
            _nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            //TODO - sprawdzić czy != null
        }

        public void AddConnection(Connection connection)
        {
            //TODO
        }
        
        public string ToMatrixString()
        {
            //TODO
            return string.Empty;
        }

        public string ToListString()
        {
            //TODO
            return string.Empty;
        }

        public string ToIncidenceMatrixString()
        {
            //TODO
            return string.Empty;
        }

    }
}
