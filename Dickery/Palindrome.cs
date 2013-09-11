using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    public static class Palindrome
    {
        public static void Run()
        {
            string line = Console.ReadLine();
            var sb = new StringBuilder();
            bool pal = false;

            // so that "a man a plan a canal panama" == true
            line = line.Replace(" ", string.Empty);

            for (int i = line.Length - 1; i >= 0; i--)
            {
                sb.Append(line[i]);
            }

            if (sb.ToString() == line)
            {
                pal = true;
            }

            Console.Write(pal.ToString());

            Console.Read();
        }
    }
}
