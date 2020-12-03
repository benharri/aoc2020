using System.Linq;

namespace aoc2020
{
    public sealed class Day3 : Day
    {
        private readonly string[] _grid;
        private readonly int _width;

        public Day3()
        {
            _grid = Input.ToArray();
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
            var slopes = new[]
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            return slopes
                .Select(s => CountSlope(s.Item1, s.Item2))
                .Aggregate((acc, i) => acc * i)
                .ToString();
        }
    }
}
