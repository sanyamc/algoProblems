using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class xlColumn
    {
        public static Dictionary<int, char> map;

        public static string ExcelColumn(int number, string result)
        {
            if (number <= 0)
                return result;


            int temp = number % 26;

            if (temp == 0)
            {
                result = "Z" + result;
                number = number - 1;
            }
            else
            {
                result = (char)(64 + temp) + result;
            }

                return ExcelColumn((number / 26), result);
            
        }

        public static void Main()
        {
            //xlColumn.map = new Dictionary<int, char>();
            //for(int i=1;i<27;i++)
            //{
            //    xlColumn.map.Add(i, ((char)(64+i)));
            //}
            Console.WriteLine(ExcelColumn(1, ""));
            Console.WriteLine(ExcelColumn(26, ""));
            Console.WriteLine(ExcelColumn(27, ""));
            Console.WriteLine(ExcelColumn(28, ""));
            Console.WriteLine(ExcelColumn(53, ""));
            Console.WriteLine(ExcelColumn(701, ""));


        }
    }
}
