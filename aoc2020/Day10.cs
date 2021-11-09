namespace aoc2020;

/// <summary>
///     Day 10: <see href="https://adventofcode.com/2020/day/10" />
/// </summary>
public sealed class Day10 : Day
{
    private readonly int[] _adapters;
    private readonly long[] _memo;

    public Day10() : base(10, "Adapter Array")
    {
        var parsed = Input.Select(int.Parse).ToArray();
        // add socket and device to the list
        _adapters = parsed.Concat(new[] { 0, parsed.Max() + 3 }).OrderBy(i => i).ToArray();
        _memo = new long[_adapters.Length];
    }

    private long Connections(int i)
    {
        if (i == _adapters.Length - 1) _memo[i] = 1;
        if (_memo[i] > 0) return _memo[i];

        for (var j = i + 1; j <= i + 3 && j < _adapters.Length; j++)
            if (_adapters[j] - _adapters[i] <= 3)
                _memo[i] += Connections(j);

        return _memo[i];
    }

    public override string Part1()
    {
        var ones = 0;
        var threes = 0;

        for (var i = 0; i < _adapters.Length - 1; i++)
            switch (_adapters[i + 1] - _adapters[i])
            {
                case 1:
                    ones++;
                    break;
                case 3:
                    threes++;
                    break;
                default: throw new Exception("something went wrong");
            }

        return $"{ones * threes}";
    }

    public override string Part2()
    {
        return $"{Connections(0)}";
    }
}
