using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 9: <see href="https://adventofcode.com/2020/day/9">Encoding Error</see>
    /// </summary>
    public sealed class Day09 : Day
    {
        private readonly long[] _list;

        public Day09() : base(9)
        {
            _list = Input.Select(long.Parse).ToArray();
        }

        public override string Part1()
        {
            var i = 25;
            while (_list.Skip(i - 25).Take(25).DifferentCombinations(2).Select(c => c.Sum()).Contains(_list[i]))
            {
                i++;
            }
            return $"{_list[i]}";
        }

        public override string Part2()
        {
            return "";
        }
    }
}
