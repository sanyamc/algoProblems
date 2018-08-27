using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Vertex<T>
    {
        private T data;
        private int index;

        public T GetData()
        {
            return this.data;
        }

        public int GetIndex()
        {
            return this.index;
        }

        public Vertex(T data, int index)
        {
            this.data = data;
            this.index = index;
        }
    }

    class Edge
    {
        public double Weight;
        public double Index;

        public Edge(double Weight, int Index)
        {
            this.Weight = Weight;
            this.Index = Index;
        }
    }
    public class Graph<T>
    {
        private Dictionary<int, List<Edge>> adjacencyList;

        public Graph()
        {
            this.adjacencyList = new Dictionary<int, List<Edge>>();
        }

        public void CreateDirectedEdge(Vertex<T> from, Vertex<T> to, double weight = 1.0)
        {
            int index = from.GetIndex();
            Edge edge = new Edge(weight, to.GetIndex());

            if (this.adjacencyList.ContainsKey(index))
            {
                this.adjacencyList[index].Add(edge);
            }
            else
            {
                var edgeList = new List<Edge>();
                edgeList.Add(edge);
                this.adjacencyList.Add(index, edgeList );
            }
        }

        public void CreateUnDirectedEdge(Vertex<T> from, Vertex<T> to, double weight = 1.0)
        {
            int index = from.GetIndex();
            int index2 = to.GetIndex();
            Edge edge1 = new Edge(weight, index2);
            Edge edge2 = new Edge(weight, index);


            if (this.adjacencyList.ContainsKey(index))
            {
                this.adjacencyList[index].Add(edge1);
            }
            else
            {
                var edgeList = new List<Edge>();
                edgeList.Add(edge1);
                this.adjacencyList.Add(index, edgeList);
            }

            if (this.adjacencyList.ContainsKey(index2))
            {
                this.adjacencyList[index2].Add(edge2);
            }
            else
            {
                var edgeList = new List<Edge>();
                edgeList.Add(edge2);
                this.adjacencyList.Add(index2, edgeList);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("Graph");
            sb.Append("\n");

            foreach (var key in this.adjacencyList.Keys)
            {

                sb.Append("V" + key + " has nodes --> ");
                foreach( var value in this.adjacencyList[key])
                {
                    sb.Append("V" + value.Index);
                    sb.Append(" ");
                }
                sb.Append("\n");

            }
            return sb.ToString();
        }



        // create directed edge
        // create undirected edge
    }


    public class TestRunner
    {
        public static void Main()
        {
            var v1 = new Vertex<int>(1, 1);
            var v2 = new Vertex<int>(2, 2);
            var v3 = new Vertex<int>(3, 3);
            var v4 = new Vertex<int>(4, 4);

            var G = new Graph<int>();
            G.CreateUnDirectedEdge(v1, v2);
            G.CreateUnDirectedEdge(v1, v3);
            G.CreateUnDirectedEdge(v2, v4);
            G.CreateUnDirectedEdge(v3, v4);

            //G.CreateDirectedEdge(v1, v2);
            //G.CreateDirectedEdge(v1, v3);
            //G.CreateDirectedEdge(v2, v4);
            //G.CreateDirectedEdge(v3, v4);

            Console.WriteLine(G.ToString());
        }
    }
}
