using System.Collections.Generic;
using System.Linq;

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
            foreach (var i in _entries)
                foreach (var j in _entries)
                    foreach (var k in _entries)
                        if (i + j + k == 2020)
                            return $"{i * j * k}";
            
            return "";
        }
    }
}
