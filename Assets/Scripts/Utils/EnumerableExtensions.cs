using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> CyclicCopy<T>(this IEnumerable<T> enumerable)
        {
            var cyclicCopy = enumerable.ToList();
            while (true)
            {
                foreach (var x in cyclicCopy)
                {
                    yield return x;
                }
            }
        }
    }
}
