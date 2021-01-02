using System.Collections.Generic;

namespace aoc2020
{
    /// <summary>
    ///     Day 19: <see href="https://adventofcode.com/2020/day/19" />
    /// </summary>
    public sealed class Day19 : Day
    {
        public Day19() : base(19, "Monster Messages")
        {
        }

        public override string Part1()
        {
            return "";
        }

        public override string Part2()
        {
            return "";
        }

        private class Rule
        {
            public int idx { get; init; }
            public List<Rule> others { get; set; }
        }
    }
}