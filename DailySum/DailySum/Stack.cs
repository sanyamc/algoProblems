using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    public class TestComparer: IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            return 1;
        }


    }
    public class StackTest
    {

        public static void Main()
        {
            Stack<int> s = new Stack<int>();

            s.Push(3);
            s.Pop();

            List<int> l = new List<int>();

            l.Add(3);
            l.Count();

            // Array list is from days when c# didn't have generics; prefer List<>
            ArrayList a = new ArrayList();


            List<float> lf = new List<float>();
            lf.Add(2.4f);

            //int IComparable.

            //IComparer<int> c = new Comparer<int>();
            //c.

            //l.Sort((int x, int y) =>
            //{
            //});
        }

    }

}
