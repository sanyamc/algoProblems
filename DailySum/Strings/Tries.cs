using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{


    public class TrieNode
    {

        private bool HasWord;
        public Dictionary<char, TrieNode> Children;

        public TrieNode()
        {

            this.Children = new Dictionary<char, TrieNode>();
            this.HasWord = false;
        }


    }

    public class SuffixTrie
    {

        private TrieNode root;
        public int MaxRepeatedSubstringLength;

        public SuffixTrie()
        {
            this.root = new TrieNode();
            this.MaxRepeatedSubstringLength = 0;

        }

        public TrieNode AddChar(char word)
        {

            var t = new TrieNode();
            t.Children[word] = new TrieNode();
            return t;


        }

        public static void PrintNodes(TrieNode root)
        {

            var current = root;
            while(current.Children.Count>0)
            {
                var keys = current.Children.Keys.ToArray();
                Console.WriteLine(keys[0]+" -->");
                current = current.Children[keys[0]];
            }

        }


        public void BuildSuffixTrie(string word)
        {
            //this.root.Children[word[word.Length-1]] = this.AddChar(word[word.Length - 1]);

            for (int i = word.Length - 1; i >= 0; i--)
            {
                var current = this.root;
                int temp = 0;
                var j = i;
                var currentChar = word[i];
                while (current.Children.ContainsKey(currentChar) && j < word.Length)
                {
                    
                    temp++;
                    current = current.Children[currentChar];
                    if (current.Children.ContainsKey(currentChar))
                        current = current.Children[currentChar];
                    j++;
                    if (j<word.Length)
                        currentChar = word[j];

                }
                this.MaxRepeatedSubstringLength = Math.Max(this.MaxRepeatedSubstringLength, temp);
                
                var newNode = this.AddChar(word[i]);
                foreach (var k in root.Children.Keys)
                {
                    newNode.Children[word[i]].Children[k] = root.Children[k];
                    PrintNodes(root.Children[k]);
                    Console.WriteLine("Adding as child of " + word[i]);
                }

                this.root = newNode;
            }
        }
    }


    public class Trie
    {

        public TrieNode root;

        public Trie()
        {
            this.root = new TrieNode();
        }


        public void AddWord(string word)
        {

            var current = this.root;

            foreach (var c in word)
            {

                var children = current.Children;
                if (!children.ContainsKey(c))
                {
                    children[c] = new TrieNode();

                }
                current = children[c];


            }
            if (!current.Children.ContainsKey('$'))
                current.Children['$'] = null;

        }

        bool FindWord(string word)
        {
            var current = this.root;

            foreach (var c in word)
            {
                var children = current.Children;
                if (!children.ContainsKey(c))
                    return false;
                current = children[c];

            }

            return current.Children.ContainsKey('$');
        }

        public List<string> PrefixMatch(string prefix)
        {

            var current = this.root;
            foreach (var c in prefix)
            {

                var children = current.Children;
                if (!children.ContainsKey(c))
                {
                    return new List<string>();
                }
                current = children[c];
            }
            var result = new List<string>();
            var currentWord = new List<char>(prefix);
            GatherAllWords(current, result, currentWord);
            return result;

        }
        private static void GatherAllWords(TrieNode current, List<string> result, List<char> currentWord)
        {

            if (current.Children.ContainsKey('$'))
                result.Add(new String(currentWord.ToArray()));

            var children = current.Children.Keys;
            foreach (var c in children)
            {
                if (c == '$')
                    continue;
                currentWord.Add(c);
                GatherAllWords(current.Children[c], result, currentWord);
                currentWord.RemoveAt(currentWord.Count - 1);
            }

        }




        public bool HasWord(string word)
        {
            return false;

        }

        



    }
}
