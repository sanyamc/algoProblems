﻿using System;
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

        public bool Visited;
        public Vertex<T> Parent;

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

    class Edge<T>
    {
        public double Weight;
        public double Index;
        public Vertex<T> From;
        public Vertex<T> To;

        public Edge(double Weight, int Index, Vertex<T> from, Vertex<T> to)
        {
            this.Weight = Weight;
            this.Index = Index;
            this.From = from;
            this.To = to;
        }
    }
    public class Graph<T>
    {
        private Dictionary<int, List<Edge<T>>> adjacencyList;
        public List<Vertex<T>> Vertices;

        public Graph()
        {
            this.adjacencyList = new Dictionary<int, List<Edge<T>>>();
            this.Vertices = new List<Vertex<T>>();
        }

        public void CreateDirectedEdge(Vertex<T> from, Vertex<T> to, double weight = 1.0)
        {
            int index = from.GetIndex();
            Edge<T> edge = new Edge<T>(weight, to.GetIndex(), from, to);
            this.Vertices.Add(from);
            this.Vertices.Add(to);

            if (this.adjacencyList.ContainsKey(index))
            {
                this.adjacencyList[index].Add(edge);
            }
            else
            {
                var edgeList = new List<Edge<T>>();
                edgeList.Add(edge);
                this.adjacencyList.Add(index, edgeList );
            }
        }

        public void CreateUnDirectedEdge(Vertex<T> from, Vertex<T> to, double weight = 1.0)
        {
            this.Vertices.Add(from);
            this.Vertices.Add(to);

            int index = from.GetIndex();
            int index2 = to.GetIndex();
            Edge<T> edge1 = new Edge<T>(weight, index2, from, to);
            Edge<T> edge2 = new Edge<T>(weight, index, to, from);


            if (this.adjacencyList.ContainsKey(index))
            {
                this.adjacencyList[index].Add(edge1);
            }
            else
            {
                var edgeList = new List<Edge<T>>();
                edgeList.Add(edge1);
                this.adjacencyList.Add(index, edgeList);
            }

            if (this.adjacencyList.ContainsKey(index2))
            {
                this.adjacencyList[index2].Add(edge2);
            }
            else
            {
                var edgeList = new List<Edge<T>>();
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

        public List<Vertex<T>> GetNeighbours(Vertex<T> vertex)
        {
            var neighbours = new List<Vertex<T>>();

            if (this.adjacencyList.ContainsKey(vertex.GetIndex()))
            {
                foreach( var e in this.adjacencyList[vertex.GetIndex()])
                {
                    neighbours.Add(e.To);
                }
            }
            return neighbours;
        }

        // create directed edge
        // create undirected edge
    }

    public class Search<T>
    {
        public static List<Vertex<T>> BFS(Graph<T> graph, Vertex<T> targetVertex, Vertex<T> rootVertex)
        {
            if (targetVertex == null || rootVertex == null)
                return null;

            if (rootVertex.GetData().Equals(targetVertex.GetData()))
            {
                return Path(rootVertex);
            }

            foreach ( var v in graph.Vertices)
            {
                v.Visited = false;
                v.Parent = null;
            }

            var q = new Queue<Vertex<T>>();
            q.Enqueue(rootVertex);

            while (q.Count > 0)
            {
                var currentVertex = q.Dequeue();

                foreach (var v in graph.GetNeighbours(currentVertex))
                {
                    if (!v.Visited)
                    {
                        v.Parent = currentVertex;
                        v.Visited = true;

                        if (v.GetData().Equals(targetVertex.GetData()))
                        {
                            return Path(v);
                        }
                        q.Enqueue(v);
                    }
                }
            }

            return null;
        }

        public static List<Vertex<T>> Path(Vertex<T> targetVertex)
        {
            var path = new List<Vertex<T>>();
            if (targetVertex == null)
                return path;

            var parent = targetVertex;
           // path.Add(targetVertex);

            while(parent != null)
            {
                path.Add(parent);
                parent = parent.Parent;
            }
            return path;
        }
    }


    public class TestRunner
    {
        //public static void Main()
        //{
        //    var v1 = new Vertex<int>(1, 1);
        //    var v2 = new Vertex<int>(2, 2);
        //    var v3 = new Vertex<int>(3, 3);
        //    var v4 = new Vertex<int>(4, 4);

        //    var G = new Graph<int>();
        //    G.CreateUnDirectedEdge(v1, v2);
        //    G.CreateUnDirectedEdge(v1, v3);
        //    G.CreateUnDirectedEdge(v2, v4);
        //    G.CreateUnDirectedEdge(v3, v4);

        //    //G.CreateDirectedEdge(v1, v2);
        //    //G.CreateDirectedEdge(v1, v3);
        //    //G.CreateDirectedEdge(v2, v4);
        //    //G.CreateDirectedEdge(v3, v4);

        //    Console.WriteLine(G.ToString());

        //    var path = Search<int>.BFS(G, v1, v4);
        //    foreach(var p in path)
        //    {
        //        Console.WriteLine("--> :" + p.GetData());
        //    }
        //}
    }
}
