using System;
using System.IO.Enumeration;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 10: <see href="https://adventofcode.com/2020/day/10">Adapter Array</see>
    /// </summary>
    public sealed class Day10 : Day
    {
        private readonly int[] _adapters;

        public Day10() : base(10)
        {
            _adapters = Input.Select(int.Parse).OrderBy(i => i).ToArray();
        }

        public override string Part1()
        {
            var ones = 1;
            var threes = 1;

            for (var i = 0; i < _adapters.Length - 1; i++)
            {
                var difference = _adapters[i + 1] - _adapters[i];
                switch (difference)
                {
                    case 1: ones++; break;
                    case 3: threes++; break;
                    default: throw new Exception("something went wrong");
                }
            }

            return $"{ones * threes}";
        }

        public override string Part2()
        {
            return "";
        }
    }
}
