using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    public class FirstNameLastNameSwitcheroo
    {
        public static void SwitchEm()
        {
            const string name = "John Doe";
            var splits = name.Split(' ');
            Console.WriteLine(splits[1] + ", " + splits[0]);
        }
    }
}
