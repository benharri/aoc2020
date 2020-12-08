using System;
using System.Collections.Immutable;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    /// Day 5: <see href="https://adventofcode.com/2020/day/5">Binary Boarding</see>
    /// </summary>
    public sealed class Day5 : Day
    {
        private readonly ImmutableHashSet<int> _ids;

        public Day5() : base(5)
        {
            _ids = Input
                .Select(s =>
                    Convert.ToInt32(s.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2))
                .OrderBy(i => i)
                .ToImmutableHashSet();
        }

        public override string Part1()
        {
            return $"{_ids.Last()}";
        }

        public override string Part2()
        {
            // arithmetic sum of full series
            return $"{(_ids.Count + 1) * (_ids.First() + _ids.Last()) / 2 - _ids.Sum()}";
        }
    }
}