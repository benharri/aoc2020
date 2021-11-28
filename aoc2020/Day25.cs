namespace aoc2020;

/// <summary>
///     Day 25: <see href="https://adventofcode.com/2020/day/25" />
/// </summary>
public sealed class Day25 : Day
{
    public Day25() : base(25, "Combo Breaker")
    {
    }

    public override string Part1()
    {
        var cardKey = int.Parse(Input.First());
        var doorKey = int.Parse(Input.Last());
        return $"{Transform(doorKey, FindLoopSize(7, cardKey))}";
    }

    public override string Part2() => "";
    
    private static long Transform(long subject, int loopSize)
    {
        var value = 1L;
        for (var i = 0; i < loopSize; i++)
        {
            value *= subject;
            value %= 20201227;
        }
        return value;
    }
    private static int FindLoopSize(long subject, int target)
    {
        var value = 1L;
        var loops = 0;
        while (value != target)
        {
            value *= subject;
            value %= 20201227;
            loops++;
        }
        return loops;
    }
}
