using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this T input)
        {
            yield return input;
        }
    }
}
