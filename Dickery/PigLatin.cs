using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    public static class PigLatin
    {
        public static void Run()
        {
            string line = Console.ReadLine();

            var split = line.Split();

            foreach (var s in split)
            {
                if (s.Length > 2)
                {
                    var first = s.Substring(1, s.Length - 1);
                    var second = s[0] + "ay ";
                    Console.Write(first + second);
                }
                else
                {
                    Console.Write(s + "lay ");
                }
            }

            Console.Read();
        }
    }
}
