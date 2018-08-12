using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Core.Enumerable
{
    public class LazyLoading
    {
        public void GetOneHandread()
        {
            int i = 0;
            var sequence = GeneratedVariable(() => i++.ToString());
            //i = 50;
            foreach (var item in sequence.Take(100))
            {
                i += 10;
                Console.WriteLine(item);
            }
        }
        public void GenerateEveryWeekdayTheSameAsTodayInTheNextYear()
        {
            var today = DateTime.Now;
            var sequence = GeneratedVariable(() =>
            {
                today += TimeSpan.FromDays(7);
                return today.Date;
            });
            foreach (var item in sequence.Take(52))
            {
                Console.WriteLine(item);
            }
        }


        public IEnumerable<string> GeneratedString()
        {
            int i = 0;
            while (i++ <= int.MaxValue)
                yield return i.ToString();
        }
        public IEnumerable<T> GeneratedVariable<T>(Func<T> itemGenerator)
        {
            int i = 0;
            while (i++ <= int.MaxValue)
                yield return itemGenerator();
        }

        public void Write()
        {
            var sequence = GeneratedString();
            var iterator = sequence.GetEnumerator();
            for (int i = 0; i < 1000; i++)
            {
                if (iterator.MoveNext())
                    Console.WriteLine(iterator.Current);
                else
                    break;
            }
        }
    }
}
