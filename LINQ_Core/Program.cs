using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Core.EF;
using LINQ_Core.Enumerable;
using LINQ_Core.Enumerator;

namespace LINQ_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumeratorExecution();
        }

        #region EnumerableLazyLoad

        private static void EnumerableLazyLoad()
        {
            LazyLoading lazy = new LazyLoading();
            lazy.GenerateEveryWeekdayTheSameAsTodayToTheNextYear();
            return;

            var map = new Map();
            //map.FilterSequence();
            map.MapSequence();
        }

        #endregion

        #region Enumerator

        private static void EnumeratorExecution()
        {
            var persons = new LINQ_Core.Enumerator.Person[]
            {
                new LINQ_Core.Enumerator.Person("Jackson", "Michael"),
                new Enumerator.Person("Steve", "Jobs"),
            };

            var people = new People(persons);
            foreach (var person in people)
            {
                Console.WriteLine($"{person.firstName} {person.lastName}");
            }
        }

        #endregion
    }
}
