using System;
using System.Linq;

namespace aoc2020
{
    public sealed class Day5 : Day
    {
        private readonly bool[] _ids;
        private readonly int _max;

        public Day5()
        {
            _ids = new bool[1024];
            _max = 0;
            foreach (var l in Input.Select(Id))
            {
                if (l > _max) _max = l;
                _ids[l] = true;
            }
        }

        public override int DayNumber => 5;

        private static int Id(string s)
        {
            var row = Convert.ToInt32(s[..7].Replace('F', '0').Replace('B', '1'), 2);
            var col = Convert.ToInt32(s[7..].Replace('L', '0').Replace('R', '1'), 2);
            return row * 8 + col;
        }

        public override string Part1()
        {
            return $"{_max}";
        }

        public override string Part2()
        {
            for (var i = 1; i < 1024; ++i)
                if (_ids[i - 1] && !_ids[i])
                    return $"{i}";

            return "";
        }
    }
}