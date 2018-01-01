using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    class Permutation
    {
        private int m_elements;

        public Permutation(int elements)
        {
            this.m_elements = elements;
        }


        public void Permute(List<int> perm, BitArray used)
        {
            if (perm.Count == m_elements)
            {
                Console.WriteLine(string.Join("", perm));
                //Console.WriteLine(perm);
                return;
            }
            for (int i = 1; i <= m_elements; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    perm.Add(i);
                    Permute(perm, used);
                    perm.RemoveAt(perm.Count - 1);
                    used[i] = false;
                }
            }
        }

        public void Generate()
        {
            this.Permute(new List<int>(), new BitArray(this.m_elements+1));
        }


        public static void Main(string[] args)
        {
            var p = new Permutation(4);
            p.Generate();
            Console.ReadLine();
        }
    }
    
}
