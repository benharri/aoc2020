using System;
using System.Diagnostics;

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

        /// <summary>
        /// increased accuracy for stopwatch based on frequency. <see href="http://geekswithblogs.net/BlackRabbitCoder/archive/2012/01/12/c.net-little-pitfalls-stopwatch-ticks-are-not-timespan-ticks.aspx">blog details here</see>
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <returns></returns>
        public static double ScaleMilliseconds(this Stopwatch stopwatch)
        {
            return 1_000 * stopwatch.ElapsedTicks / (double) Stopwatch.Frequency;
        }
    }
}