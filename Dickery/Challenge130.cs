using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    /// <summary>
    /// http://www.reddit.com/r/dailyprogrammer/comments/1givnn/061713_challenge_130_easy_roll_the_dies/
    /// </summary>
    public static class Challenge130
    {
        private static readonly Random rand = new Random();

        public static void Run()
        {
            while (true)
            {
                var line = Console.ReadLine();

                var split = line.Split('d');

                try
                {
                    var num = Convert.ToInt32(split[0]);
                    var size = Convert.ToInt32(split[1]);
                    var count = 0;

                    for (int i = 1; i <= num; i++)
                    {
                        var roll = rand.Next(1, size + 1);
                        Console.WriteLine("Roll " + i + ": " + roll);
                        count += roll;
                    }

                    Console.WriteLine("Total: " + count + "\r\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetType());
                }
            }
        }
    }
}
