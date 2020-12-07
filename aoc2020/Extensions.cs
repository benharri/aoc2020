using System;

namespace aoc2020
{
    public static class Extensions
    {
        public static string TrimEnd(this string source, string value)
        {
            return !source.EndsWith(value)
                ? source
                : source.Remove(source.LastIndexOf(value, StringComparison.Ordinal));
        }
    }
}