using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Vertex
    {
        public string label;
        public Vertex bfs_parent;
        public Vertex(string word)
        {
            this.label = word;
            this.bfs_parent = null;
        }
    }


    public class Solution
    {

        private Dictionary<string, List<string>> adjList;
        private Dictionary<string, Vertex> vMap;
        private HashSet<string> seen;
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {

            if (this.adjList == null)
            {
                wordList.Add(beginWord);
                wordList.Add(endWord);
                this.adjList = new Dictionary<string, List<string>>();
                this.vMap = new Dictionary<string, Vertex>();
                this.BuildGraph(wordList);
            }

            this.seen = new HashSet<string>();

            IList<IList<string>> res = new List<IList<string>>();

            Explore(beginWord, endWord, res);
            return res;

        }

        private void Explore(string begin, string end, IList<IList<string>> res)
        {

            var q = new Queue<string>();
            q.Enqueue(begin);
            this.seen.Add(begin);
            int minPath = Int32.MaxValue;
         //   int currDepth = 0;

            while (q.Count > 0)
            {

                var currWord = q.Dequeue();

                var curr = this.vMap[currWord];
                //currDepth++;

                foreach (var n in this.adjList[currWord])
                {
                    var nV = this.vMap[n];

                    if (n == end)
                    {
                        nV.bfs_parent = curr;
                        var path = new List<string>();

                        ConstructPath(nV, path, begin);
                        if (path.Count > minPath)
                            return;
                        minPath = Math.Min(minPath, path.Count);

                        res.Add(path);
                    }
                    else if (!this.seen.Contains(n))
                    {
                        nV.bfs_parent = curr;
                        this.seen.Add(n);
                        q.Enqueue(n);

                    }
                    // else if (this.seen.Contains(n) ) {
                    //     nV.bfs_parent = curr;
                    // }
                }
            }

        }

        private void ConstructPath(Vertex node, List<string> path, string start)
        {
            var curr = node;
            while (curr.bfs_parent != null && curr.bfs_parent.label != start)
            {
                path.Add(curr.bfs_parent.label);
                curr = curr.bfs_parent;
            }
            path.Add(start);
            path.Reverse();
            path.Add(node.label);
        }


        private void BuildGraph(IList<string> wordList)
        {

            for (int i = 0; i < wordList.Count; i++)
            {
                var word = wordList[i];
                if (!this.adjList.ContainsKey(word))
                {
                    this.adjList.Add(word, new List<string>());
                    this.vMap.Add(word, new Vertex(word));
                }

                for (int j = i + 1; j < wordList.Count; j++)
                {
                    var word2 = wordList[j];
                    if (isOneAway(word2, word))
                    {
                        this.adjList[word].Add(word2);
                        if (!this.adjList.ContainsKey(word2))
                        {
                            this.adjList.Add(word2, new List<string>());
                            this.vMap.Add(word2, new Vertex(word2));
                        }
                        this.adjList[word2].Add(word);

                    }
                }


            }
        }

        private bool isOneAway(string word1, string word2)
        {
            if (Math.Abs(word1.Length - word2.Length) > 1)
                return false;

            int i = 0, j = 0, count = 0;

            while (i < word1.Length && j < word2.Length)
            {
                if (count > 1)
                    return false;

                if (word1[i] != word2[j])
                {
                    count++;
                }
                i++;
                j++;
            }
            return count <= 1;
        }

        public static void Main()
        {
            var s = new Solution();

            var l = new List<string>() { "hot", "dot", "log", "dog", "lot" };

            s.FindLadders("hit", "cog", l);

        }

    }
}
