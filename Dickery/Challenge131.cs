using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    /// <summary>
    /// http://www.reddit.com/r/dailyprogrammer/comments/1heozl/070113_challenge_131_easy_who_tests_the_tests/
    /// </summary>
    public static class Challenge131
    {
        private const string GoodJob = "Good test data";
        private const string BadJob = "Mismatch! Bad test data";
        private const string WhatJob = "What were you thinking, man?";

        public static void Run()
        {
            int start = Convert.ToInt32(Console.ReadLine());
            var input = new string[start];

            for (var i = 0; i < start; i++)
            {
                input[i] = Console.ReadLine();
            }

            for (var i = 0; i < start; i++)
            {
                var split = input[i].Split();

                try
                {
                    switch (input[i][0])
                    {
                        case '0':
                            var reversed = ReverseAString.Run(split[2]);
                            Console.WriteLine(split[1] == reversed ? GoodJob : BadJob);
                            break;
                        case '1':
                            Console.WriteLine(split[1].ToUpperInvariant() == split[2].ToUpperInvariant() ? GoodJob : BadJob);
                            break;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine(WhatJob);
                    continue;
                }
            }

            Console.ReadLine();
        }
    }
}
