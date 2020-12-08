using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    /// Day 6: <see href="https://adventofcode.com/2020/day/6">Custom Customs</see>
    /// </summary>
    public sealed class Day06 : Day
    {
        private readonly int _countPart1;
        private readonly int _countPart2;

        public Day06() : base(6)
        {
            var alphabet = "abcedfghijklmnopqrstuvwxyz".ToCharArray();
            _countPart1 = 0;
            _countPart2 = 0;
            var s = new HashSet<char>();
            var lines = new HashSet<string>();
            foreach (var line in Input)
            {
                if (line == "")
                {
                    _countPart1 += s.Count;
                    _countPart2 += alphabet.Count(a => lines.All(l => l.Contains(a)));
                    s.Clear();
                    lines.Clear();
                    continue;
                }

                foreach (var c in line)
                    s.Add(c);
                lines.Add(line);
            }

            if (s.Any())
            {
                _countPart1 += s.Count;
                _countPart2 += alphabet.Count(a => lines.All(l => l.Contains(a)));
            }
        }

        public override string Part1()
        {
            return $"{_countPart1}";
        }

        public override string Part2()
        {
            return $"{_countPart2}";
        }
    }
}