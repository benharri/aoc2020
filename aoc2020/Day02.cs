using System.Collections.Immutable;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 2: <see href="https://adventofcode.com/2020/day/1">Password Philosophy</see>
    /// </summary>
    public sealed class Day02 : Day
    {
        private readonly ImmutableList<Password> _passwords;

        public Day02() : base(2)
        {
            _passwords = Input.Select(p => new Password(p)).ToImmutableList();
        }

        public override string Part1()
        {
            return $"{_passwords.Count(p => p.IsValid)}";
        }

        public override string Part2()
        {
            return $"{_passwords.Count(p => p.IsValidByIndex)}";
        }

        private class Password
        {
            public Password(string line)
            {
                var split = line.Split(": ", 2);
                var split2 = split[0].Split(' ', 2);
                var indices = split2[0].Split('-', 2);
                I = int.Parse(indices[0]);
                J = int.Parse(indices[1]);
                C = char.Parse(split2[1]);
                Value = split[1];
            }

            public bool IsValid =>
                Count >= I && Count <= J;

            public bool IsValidByIndex =>
                (Value[I - 1] == C) ^ (Value[J - 1] == C);

            private int Count =>
                Value.Count(p => p == C);

            private int I { get; }
            private int J { get; }
            private char C { get; }
            private string Value { get; }
        }
    }
}