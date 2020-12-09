using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 9: <see href="https://adventofcode.com/2020/day/9">Encoding Error</see>
    /// </summary>
    public sealed class Day09 : Day
    {
        private readonly long[] _list;
        private long _part1;

        public Day09() : base(9)
        {
            _list = Input.Select(long.Parse).ToArray();
        }

        public override string Part1()
        {
            var i = 25;
            while (_list.Skip(i - 25).Take(25).Combinations(2).Select(c => c.Sum()).Contains(_list[i])) i++;
            _part1 = _list[i];
            return $"{_list[i]}";
        }

        public override string Part2()
        {
            for (var i = 0; i < _list.Length - 1; i++)
            {
                var offset = 1;
                while (_list.Skip(i).Take(offset).Sum() < _part1) offset++;

                var subset = _list.Skip(i).Take(offset).ToArray();
                if (subset.Sum() != _part1) continue;

                var min = subset.Min();
                var max = subset.Max();
                return $"{min + max}";
            }

            return "";
        }
    }
}