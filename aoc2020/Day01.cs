namespace aoc2020;

/// <summary>
///     Day 1: <see href="https://adventofcode.com/2020/day/1" />
/// </summary>
public sealed class Day01 : Day
{
    private readonly ImmutableHashSet<int> _entries;

    public Day01() : base(1, "Report Repair")
    {
        _entries = Input.Select(int.Parse).ToImmutableHashSet();
    }

    public override string Part1()
    {
        var entry = _entries.First(e => _entries.Contains(2020 - e));
        return $"{entry * (2020 - entry)}";
    }

    public override string Part2()
    {
        foreach (var i in _entries)
            foreach (var j in _entries)
                foreach (var k in _entries)
                    if (i + j + k == 2020)
                        return $"{i * j * k}";

        return "";
    }
}
