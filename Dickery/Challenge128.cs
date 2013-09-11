using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    /// <summary>
    /// http://www.reddit.com/r/dailyprogrammer/comments/1g7gyi/061213_challenge_128_intermediate_covering/
    /// </summary>
    public static class Challenge128
    {
        private const string input =
@"5
1 4 0 2 2
1 4 1 5 3
2 0 0 0 1
2 4 0 5 2
2 0 0 4 0";

        public static void Run()
        {
            Console.WriteLine(input);
            var theData = ProcessInput(input);
            DisplayOutput(theData);
            Console.ReadLine();
        }

        private static char[,] ProcessInput(string input)
        {
            string[] lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var size = Convert.ToInt32(lines[0]);

            var result = new char[size, size];

            var colCounter = new int[size];

            for (int i = 1; i <= size; i++)
            {
                var line = lines[i].Split();
                bool repairRow = line.Where(x => x == "0").Count() > 1;
                if (repairRow) Console.WriteLine("Repairing Row: " + (i - 1));

                for (int j = 0; j < size; j++)
                {
                    bool repairHole = line[j][0] == '0';
                    result[i - 1, j] = repairHole || repairRow ? 'X' : line[j][0];
                    if (repairHole) colCounter[j]++;
                }
            }

            for (int i = 0; i < colCounter.Length; i++)
            {
                if (colCounter[i] > 1) Console.WriteLine("Repairing Column: " + i);
            }

            return result;
        }

        private static void DisplayOutput(char[,] output)
        {
            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    Console.Write(output[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
