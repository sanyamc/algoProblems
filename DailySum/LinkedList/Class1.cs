using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public TrieNode()
        {
            this.Children = new Dictionary<char, TrieNode>();
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
                if (!current.Children.ContainsKey(c))
                {
                    current.Children[c] = new TrieNode();
                }
                current = current.Children[c];

            }
            current.Children['$'] = new TrieNode();
        }

        public bool IsPalindrom(char[] word, int startIndex)
        {
            if (word.Length == 1)
                return true;

            int i = startIndex;
            int j = word.Length - 1;

            while (i <= j)
            {
                if (word[i] != word[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }

        public List<string> CheckTrieAndPalindrom(TrieNode t, char[] word)
        {

            var current = t;
            var i = 0;
            var result = new List<string>();
            var path = new List<char>();

            while (current.Children.Count > 0 && i < word.Length)
            {

                if (!current.Children.ContainsKey(word[i]))
                {
                    if (i > 0 && current.Children.ContainsKey('$'))
                    {
                        var temp = this.IsPalindrom(word, i);
                        if (temp)
                        {

                            Array.Reverse(word);
                            result.Add(new String(word));
                            result.Add(new String(path.ToArray()));
                            return result;
                        }
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    path.Add(word[i]);
                    current = current.Children[word[i]];
                    i++;
                }

            }

            if (current.Children.Count == 1 && i == word.Length && current.Children.ContainsKey('$'))
            {
                Array.Reverse(word);
                result.Add(new String(word));
                result.Add(new String(path.ToArray()));
                return result;
            }
            //return true;

            if (current.Children.Count == 1 && current.Children.ContainsKey('$'))
            {
                var c = this.IsPalindrom(word, i);
                if (c)
                {
                    Array.Reverse(word);
                    result.Add(new String(word));
                    result.Add(new String(path.ToArray()));
                }
            }

            return result;
        }

    


    /*
     * Complete the join_words_to_make_a_palindrome function below.
     */
    public static string[] join_words_to_make_a_palindrome(string[] words)
    {
        /*
         * Write your code here.
         */

        var t = new Trie();
        

        //var result = false;

        foreach (var word in words)
        {
            var r = word.ToArray();
            Array.Reverse(r);
            var result = t.CheckTrieAndPalindrom(t.root, r);
            if (result.Count != 0)
                return result.ToArray();

            t.AddWord(word);
        }
        var te = new List<string>();
        te.Add("NOTFOUND");
        te.Add("DNUOFTON");
        return te.ToArray();
    }

    //public static void Main()
    //    {
    //        string[] words = {"abcdefgh", "mno"};
    //        join_words_to_make_a_palindrome(words);
    //    }

    }






}
