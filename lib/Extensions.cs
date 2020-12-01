using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020.lib
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0
                ? Enumerable.Repeat(Enumerable.Empty<T>(), 1)
                : elements.SelectMany((e, i) =>
                    elements.Skip(i + 1).Combinations(k - 1).Select(c => Enumerable.Repeat(e, 1).Concat(c)));
        }
    }
}
