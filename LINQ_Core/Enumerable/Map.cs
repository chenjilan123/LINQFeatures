using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Core.Enumerable
{
    public static class MyLINQImplement
    {
        public static IEnumerable<string> Where(this IEnumerable<string> source)
        {
            foreach (var item in source)
                if (item.Length < 2)
                    yield return item;
        }
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
                if (predicate(item))
                    yield return item;
        }
    }

    public class Map
    {
        public void FilterSequence()
        {
            //var sequence = GeneratedSequence();
            //sequence = sequence.Where(s => s.Length < 3);
            //foreach (var item in sequence)
            //    Console.WriteLine(item);

            var sequence = GeneratedIntSequence().Take(1000);
            sequence = sequence.Where(i => i % 3 == 0);
            foreach (var item in sequence)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Use select to map things to other type
        /// </summary>
        public void MapSequence()
        {
            var sequence = GeneratedIntSequence().Select(n => n.ToString());
            sequence = sequence.Where(s => s.Length < 3);
            foreach (var item in sequence)
                Console.WriteLine(item);

        }



        private IEnumerable<string> GeneratedSequence()
        {
            int i = 0;
            while (i++ <= int.MaxValue)
                yield return i.ToString();
        }
        private IEnumerable<int> GeneratedIntSequence()
        {
            int i = 0;
            while (i++ <= int.MaxValue)
                yield return i;
        }
    }
}
