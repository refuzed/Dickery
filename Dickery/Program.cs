 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Dickery
{
    class Program
    {
        static void Main(string[] args)
        {
            //PigLatin.Run();
            //ReverseAString.Run();
            //CountVowels.Run();
            //Palindrome.Run();
            //Challenge128.Run();
            //FizzBuzz.Run();

            var lick = new Lictionary<int, string>();

            lick.Add(1, "Hi");
            lick.Add(2, "Boobs");
            lick.Add(1, "Oh Hello");

            var messages = lick.GetValues(1);

            foreach (var message in messages)
                Console.WriteLine(message);

            Console.ReadLine();

            lick.RemoveValueFromKey(1, "Hi");

            messages = lick.GetValues(1);

            foreach (var message in messages)
                Console.WriteLine(message);

            Console.ReadLine();
        }
    }
}
