using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    public sealed class Day6 : Day
    {
        private readonly int _countPart1;
        private readonly int _countPart2;

        public Day6()
        {
            _countPart1 = 0;
            var s = new HashSet<char>();
            foreach (var line in Input)
            {
                if (line == "")
                {
                    _countPart1 += s.Count;
                    s.Clear();
                }

                foreach (var c in line)
                    s.Add(c);
            }

            if (s.Any()) _countPart1 += s.Count;
        }
        
        public override int DayNumber => 6;
        public override string Part1()
        {
            return $"{_countPart1}";
        }

        public override string Part2()
        {
            return "";
        }
    }
}
