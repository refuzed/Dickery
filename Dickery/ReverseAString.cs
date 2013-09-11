using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    public static class ReverseAString
    {
        public static string Run(string line)
        {
            var array = line.ToArray();
            Array.Reverse(array);
            return new String(array);
        }
    }
}
