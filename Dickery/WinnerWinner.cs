using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    public static class WinnerWinner
    {
        public static void Run()
        {
            var contestants = new Dictionary<string, int> 
            { 
                { "Chistopher Santana", 1 }, 
                { "Steven Thacker", 1 },
                { "Kyle Monteith", 1 },
                { "Jacob Hurst", 1 },
                { "Alex Koreneff", 2 },
                { "Don Grey", 2  },
                { "Michael Ma", 1 },
            };

            //contestants
            //    .GetWeightedList()
            //    .Write("Weighted:")
            //    .Randomize()
            //    .Write("Randomized:")
            //    .OrderedDistinct()
            //    .Write("Ordered:");

            contestants.GetLucky().OrderByDescending(x => x.Value).Write();
        }
    }

    public static class WinnerExtensions 
    {
        public static Dictionary<TKey, int> GetLucky<TKey>(this Dictionary<TKey, int> source)
        {
            var rand = new Random();
            var keys = new List<TKey>(source.Keys);

            for (int i = 0; i < keys.Count; i++)
            {
                var key = keys[i];
                var weight = source[key];

                source[key] = 0;
                for (int j = 0; j < weight; j++)
                {
                    source[key] = Math.Max(source[key], rand.Next(1, 100));
                }
            }

            return source;
        }

        public static IEnumerable<TKey> GetWeightedList<TKey>(this Dictionary<TKey, int> source)
        {
            foreach (var item in source)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    yield return item.Key;
                }
            }
        }

        public static IEnumerable<TSource> Randomize<TSource>(this IEnumerable<TSource> source)
        {
            var rand = new Random();
            return source.OrderBy<TSource, int>(x => rand.Next()).ToArray();
        }

        // Created because System.Linq.Enumerable.Distinct() is not guaranteed to be ordered
        public static IEnumerable<TSource> OrderedDistinct<TSource>(this IEnumerable<TSource> source)
        {
            var hash = new HashSet<TSource>();
            foreach (var item in source)
            {
                if (!hash.Contains(item))
                {
                    hash.Add(item);
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Write<TSource>(this IEnumerable<TSource> source, string message = null)
        {
            Console.WriteLine();
            Console.WriteLine(message);

            foreach (var item in source)
            {
                Console.WriteLine(item);
            }

            return source;
        }
    }
}
