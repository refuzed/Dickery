using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Dickery
{
    public class Hash
    {
        private static int testRuns = 10000000;
        private static int listSize = 1000;
        private static int containSize = 50;

        public static void RunTestArray()
        {
            var contains = new int[containSize];
            for (int i = 0; i < containSize; i++)
            {
                contains[i] = i;
            }

            var testlist = new List<int>();
            for (int i = 0; i < listSize; i++)
            {
                testlist.Add(i);
            }

            var rando = new Random();

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < testRuns; i++)
            {
                var test = testlist.ElementAt(rando.Next(testlist.Count()));
                contains.Contains(test); 
            }
            sw.Stop();

            Console.Write("Array:");
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static void RunTestHash()
        {
            var contains = new HashSet<int>();
            for (int i = 0; i < containSize; i++)
            {
                contains.Add(i);
            }

            var testlist = new List<int>();
            for (int i = 0; i < listSize; i++)
            {
                testlist.Add(i);
            }

            var rando = new Random();

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < testRuns; i++)
            {
                var test = testlist.ElementAt(rando.Next(testlist.Count()));
                contains.Contains(test);
            }
            sw.Stop();

            Console.Write("Hash:");
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static void RunTestList()
        {
            var contains = new List<int>();
            for (int i = 0; i < containSize; i++)
            {
                contains.Add(i);
            }

            var testlist = new List<int>();
            for (int i = 0; i < listSize; i++)
            {
                testlist.Add(i);
            }

            var rando = new Random();

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < testRuns; i++)
            {
                var test = testlist.ElementAt(rando.Next(testlist.Count()));
                contains.Contains(test);
            }
            sw.Stop();

            Console.Write("List:");
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

    }
}
