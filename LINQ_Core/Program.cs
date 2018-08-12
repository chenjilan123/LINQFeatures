using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Core.Enumerable;

namespace LINQ_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            //LazyLoading lazy = new LazyLoading();
            //lazy.GenerateEveryWeekdayTheSameAsTodayInTheNextYear();

            var map = new Map();
            map.FilterSequence();
            map.MapSequence();

        }
    }
}
