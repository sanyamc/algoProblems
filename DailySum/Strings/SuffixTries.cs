using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class RepeatedResult
    {
        public int depth;
        public string path;
        public RepeatedResult(int depth, string path)
        {
            this.depth = depth;
            this.path = path;
        }
    }

    public class SuffixTries
    {



        private TrieNode root;

        public SuffixTries()
        {

            this.root = new TrieNode();
        }

        public void AddWord(string word)
        {
            var current = this.root;

            foreach (var c in word)
            {

                if (!current.Children.ContainsKey(c))
                {
                    current.Children[c] = new TrieNode();
                }

                current = current.Children[c];

            }
            current.Children['$'] = new TrieNode();
        }


        public void BuildSuffixTrees(string word)
        {

            for (int i = 0; i < word.Length; i++)
            {

                this.AddWord(word.Substring(i));
            }
        }

        public RepeatedResult FindRepeatedResult(TrieNode root, int depth, List<char> path)
        {
            RepeatedResult result = new RepeatedResult(0, "");
            if (root.Children.Count == 0)
                return new RepeatedResult(0, "");
            var currentMax = 0;
            //var current
            foreach(var c in root.Children.Keys)
            {
                
                path.Add(c);
                var r = FindRepeatedResult(root.Children[c], depth + 1, path);
                path.RemoveAt(path.Count - 1);
                if (r.depth > currentMax)
                {
                    result = r;
                    currentMax = r.depth;
                }
                
            }
            if (currentMax == 0 && root.Children.Count > 1)
            {
                var r = new String(path.ToArray());
                return new RepeatedResult(depth, r);
            }
            return result;
                



           // return result;

        }

        public void PrintSuffixTrie(TrieNode root, List<char> output)
        {

            var current = root;
            var keys = root.Children.Keys.ToList();
            if (keys.Count == 0)
            {
                foreach(var c in output)
                {
                    Console.Write(c + " -->");
                }
                Console.WriteLine();
                return;
            }
            foreach (var c in keys)
            {
                //Console.Write(c + " --> ");
                output.Add(c);
                //current = current.Children[c];
                PrintSuffixTrie(current.Children[c], output);
                output.RemoveAt(output.Count - 1);
            }
        }

        

        public static void Main()
        {
            //var t = new Trie();

            //t.AddWord("test");
            //t.AddWord("testing");
            //t.AddWord("cat");
            //t.AddWord("bat");
            //t.AddWord("cast");

            //var r = t.PrefixMatch("b");
            //foreach(var s in r)
            //{
            //    Console.WriteLine(s);
            //}

            var t = new SuffixTries();
            t.BuildSuffixTrees("aaa");
            t.PrintSuffixTrie(t.root, new List<char>());
            var r = t.FindRepeatedResult(t.root, 0, new List<char>());
            //SuffixTrie.PrintNodes(t.root);

            //t.BuildSuffixTrie("Mississippi");
            //Console.WriteLine("length is: " + t.MaxRepeatedSubstringLength);
        }
    }


}
