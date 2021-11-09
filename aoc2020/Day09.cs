namespace aoc2020;

/// <summary>
///     Day 9: <see href="https://adventofcode.com/2020/day/9" />
/// </summary>
public sealed class Day09 : Day
{
    private readonly long[] _list;
    private long _part1;

    public Day09() : base(9, "Encoding Error")
    {
        _list = Input.Select(long.Parse).ToArray();
    }

    public override string Part1()
    {
        for (var i = 25; i < _list.Length - 25; i++)
        {
            var preamble = _list[(i - 25)..i];
            if (!preamble.Any(num1 => preamble.Any(num2 => num1 + num2 == _list[i])))
            {
                _part1 = _list[i];
                return $"{_part1}";
            }
        }

        return "";
    }

    public override string Part2()
    {
        for (var i = 0; i < _list.Length; i++)
        {
            long sum = 0;
            for (var j = i; j < _list.Length; j++)
            {
                sum += _list[j];
                if (sum > _part1) break;
                if (sum != _part1) continue;

                var subset = _list[i..(j + 1)].ToArray();
                return $"{subset.Min() + subset.Max()}";
            }
        }

        return "";
    }
}
