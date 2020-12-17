using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 17: <see href="https://adventofcode.com/2020/day/17" />
    /// </summary>
    public sealed class Day17 : Day
    {
        private char[,,] space;
        public Day17() : base(17, "Conway Cubes")
        {
            space = new char[100, 100, 100];
            var input = Input.ToList();
            
            for (var y = 0; y < input.Count; y++)
            {
                var l = input[y].ToCharArray();
                for (var x = 0; x < l.Length; x++)
                {
                    space[x, y, 0] = l[x];
                }
            }
        }

        public override string Part1()
        {
            return "";
        }

        public override string Part2()
        {
            return "";
        }
    }
}