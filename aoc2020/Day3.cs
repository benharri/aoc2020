using System.Linq;

namespace aoc2020
{
    public sealed class Day3 : Day
    {
        private readonly string[] _grid;

        public Day3()
        {
            _grid = Input.ToArray();
        }

        public override int DayNumber => 3;

        private int CountSlope(int di, int dx)
        {
            var hits = 0;
            for (int i = 0, x = 0; i < _grid.Length; i += di, x = (x + dx) % _grid.First().Length)
                if (_grid[i][x] == '#')
                    hits++;

            return hits;
        }

        public override string Part1()
        {
            return $"{CountSlope(1, 3)}";
        }

        public override string Part2()
        {
            return $@"{CountSlope(1, 1)
                       * CountSlope(1, 3)
                       * CountSlope(1, 5)
                       * CountSlope(1, 7)
                       * CountSlope(2, 1)}";
        }
    }
}