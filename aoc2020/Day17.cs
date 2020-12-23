using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 17: <see href="https://adventofcode.com/2020/day/17" />
    /// </summary>
    public sealed class Day17 : Day
    {
        private Dictionary<(int x, int y, int z), char> _plane;

        public Day17() : base(17, "Conway Cubes")
        {
            _plane = new Dictionary<(int x, int y, int z), char>();
            var input = Input.ToList();

            for (var x = 0; x < 32; x++)
            for (var y = 0; y < 32; y++)
            for (var z = 0; z < 32; z++)
                _plane[(x, y, z)] = '.';

            for (var y = 0; y < input.Count; y++)
            for (var x = 0; x < input[y].Length; x++)
                _plane[(x, y, 0)] = input[y][x];
        }

        private int Neighbors(int x, int y, int z)
        {
            var neighbors = 0;

            foreach (var i in new[] {-1, 0, 1})
            foreach (var j in new[] {-1, 0, 1})
            foreach (var k in new[] {-1, 0, 1})
            {
                if (i == 0 && j == 0 && k == 0 || !_plane.ContainsKey((x + i, y + j, z + k))) continue;
                if (_plane[(x + i, y + j, z + k)] == '#') neighbors++;
            }

            return neighbors;
        }

        private Dictionary<(int x, int y, int z), char> Iterate(Dictionary<(int x, int y, int z), char> prev)
        {
            var next = new Dictionary<(int x, int y, int z), char>();
            
            for (var z = 0; z < 32; z++)
            for (var y = 0; y < 32; y++)
            for (var x = 0; x < 32; x++)
            { 
                var active = Neighbors(x, y, z);
                if (_plane[(x, y, z)] == '#')
                    next[(x, y, z)] = active == 2 || active == 3 ? '#' : '.';
                else
                    next[(x, y, z)] = active == 3 ? '#' : '.';
            }

            return next;
        }

        public override string Part1()
        {
            foreach (var _ in Enumerable.Range(0, 6))
            {
                var next = Iterate(_plane);
                _plane = next;
            }

            return $"{_plane.Values.Count(v => v == '#')}";
        }

        public override string Part2()
        {
            return "";
        }
    }
}