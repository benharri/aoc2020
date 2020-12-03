using System.IO;
using System.Linq;
using System.Numerics;

namespace aoc2020
{
    public sealed class Day3 : Day
    {
        private readonly string[] _grid;
        private readonly int _width;

        public Day3()
        {
            _grid = File.ReadLines("input/day3big.in").ToArray();
            _width = _grid[0].Length;
        }

        public override int DayNumber => 3;

        private long CountSlope(int dx, int dy)
        {
            long hits = 0;
            for (int x = 0, y = 0; y < _grid.Length; y += dy, x = (x + dx) % _width)
                if (_grid[y][x] == '#')
                    hits++;

            return hits;
        }

        public override string Part1()
        {
            return $"{CountSlope(3, 1)}";
        }

        public override string Part2()
        {
            var xSlops = new[] {2, 3, 4, 5, 8, 9, 12, 16, 18, 24, 32, 36, 48, 54, 65};
            var ySlops = new[] {1, 5, 7, 11, 13, 17, 19, 23, 25, 29, 31, 25, 37, 41, 47};

            return xSlops
                .SelectMany(x => ySlops, (x, y) => (x, y))
                .Select(s => CountSlope(s.Item1, s.Item2))
                .Select(s => new BigInteger(s))
                .Aggregate(BigInteger.Multiply)
                .ToString();
        }
    }
}
