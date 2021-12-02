using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    internal static class ExtensionMethods 
    {
        public static void PrintLine<T>(this List<T> list)
        {
            Console.WriteLine("PrintLine start");
            foreach(T item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("PrintLine end");
        }
        public static void Print<T>(this List<T> list)
        {
            foreach(T item in list)
            {
                Console.Write("Print start " + item + " ");
            }
        }
    }
}
