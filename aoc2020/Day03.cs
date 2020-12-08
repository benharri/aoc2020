using System.Linq;

namespace aoc2020
{
    /// <summary>
    /// Day 3: <see href="https://adventofcode.com/2020/day/3">Toboggan Trajectory</see>
    /// </summary>
    public sealed class Day03 : Day
    {
        private readonly string[] _grid;
        private readonly int _width;

        public Day03() : base(3)
        {
            _grid = Input.ToArray();
            _width = _grid[0].Length;
        }

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
            var xSlopes = new[] {1, 3, 5, 7, 1};
            var ySlopes = new[] {1, 1, 1, 1, 2};

            return xSlopes.Zip(ySlopes)
                .Select(s => CountSlope(s.Item1, s.Item2))
                .Aggregate((acc, i) => acc * i)
                .ToString();
        }
    }
}