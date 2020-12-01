using System.Collections.Generic;
using System.Linq;
using aoc2020.lib;

namespace aoc2020
{
    internal sealed class Day1 : Day
    {
        public override int DayNumber => 1;

        private readonly List<int> _entries;

        public Day1()
        {
            _entries = Input.Select(int.Parse).ToList();
        }

        public override string Part1()
        {
            var entry = _entries.First(e => _entries.Contains(2020 - e));
            return $"{entry * (2020 - entry)}";
        }

        public override string Part2()
        {
            var threes = _entries.Combinations(3).Single(e => e.Sum() == 2020);
            return threes.Aggregate(1, (acc, val) => acc * val).ToString();
        }
    }
}
