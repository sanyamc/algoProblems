using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    public class Xor
    {
        public static int? duplicate(IEnumerable<int> values)
        {
            int? dupe = null;
            if (values == null || values.Count() < 2)
                return dupe;
            int running = values.ElementAt<int>(0);

            for(int i=1;i<values.Count(); i++)
            {
                running ^= values.ElementAt(i);
                if (running == 0)
                    return values.ElementAt(i);

            }

            return dupe;
        }


        public static void Main()
        {
            List<int> temp = new List<int>();
            temp.Add(1);
            temp.Add(4);
            temp.Add(2);
            temp.Add(3);
            temp.Add(4);

            Console.WriteLine(Xor.duplicate(temp));
        }
    }
}
