using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CountVowels
{
    public static void Run()
    {
        string line = Console.ReadLine();
        int[] count = new int[5];

        foreach (var c in line)
        {
            switch (c)
            {
                case 'a':
                    count[0]++;
                    break;
                case 'e':
                    count[1]++;
                    break;
                case 'i':
                    count[2]++;
                    break;
                case 'o':
                    count[3]++;
                    break;
                case 'u':
                    count[4]++;
                    break;
                default:
                    continue;
            }
        }

        Console.WriteLine("a: " + count[0]);
        Console.WriteLine("e: " + count[1]);
        Console.WriteLine("i: " + count[2]);
        Console.WriteLine("o: " + count[3]);
        Console.WriteLine("u: " + count[4]);

        Console.Read();
    }
}