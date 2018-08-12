using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Core.Enumerable
{
    /// <summary>
    /// ①The implement build-in of .net is just like this.
    /// ②We can add some domain specific extention jus like this
    /// </summary>
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
            var save = Console.ForegroundColor;
            foreach (var item in source)
            {
                //Do somethine like loging
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"item = {item}");
                Console.ForegroundColor = save;
                if (predicate(item))
                    yield return item;
            }
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
                yield return selector(item);
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source
            , Func<TSource, int, TResult> selector)
        {
            //var save = Console.ForegroundColor;
            int index = 0;
            foreach (var item in source)
            {
                //Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine($"item = {item}");
                //Console.WriteLine($"Index = {index}");
                //Console.ForegroundColor = save;
                yield return selector(item, index++);
            }
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
            var sequence = GeneratedIntSequence().Take(1000).Where(n => n % 5 == 0).Select((n, Index) =>
                new { Index, formattedResult = n.ToString().PadLeft(20) });
            foreach (var item in sequence)
                //Console.WriteLine($"Index: {item.Index}, Result: {item.formattedResult}");
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
