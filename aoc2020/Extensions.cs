using System.Diagnostics;

namespace aoc2020;

public static class Extensions
{
    /// <summary>
    ///     increased accuracy for stopwatch based on frequency.
    ///     <see
    ///         href="http://geekswithblogs.net/BlackRabbitCoder/archive/2012/01/12/c.net-little-pitfalls-stopwatch-ticks-are-not-timespan-ticks.aspx">
    ///         blog
    ///         details here
    ///     </see>
    /// </summary>
    /// <param name="stopwatch"></param>
    /// <returns></returns>
    public static double ScaleMilliseconds(this Stopwatch stopwatch)
    {
        return 1_000 * stopwatch.ElapsedTicks / (double)Stopwatch.Frequency;
    }

    public static bool Contains(this Range range, int i)
    {
        return i >= range.Start.Value && i <= range.End.Value;
    }
}
