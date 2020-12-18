using System;
using System.Collections.Generic;

namespace aoc2020
{
    /// <summary>
    ///     Day 18: <see href="https://adventofcode.com/2020/day/18" />
    /// </summary>
    public sealed class Day18 : Day
    {
        public Day18() : base(18, "Operation Order")
        {
        }

        public override string Part1()
        {
            foreach (var line in Input)
            {
                var spl = line.Split(' ', StringSplitOptions.TrimEntries);
                var operands = new List<int>();
                var operators = new List<Func<int, int, int>>();

                foreach (var s in spl)
                {
                    var parenCount = 0;
                    if (s.StartsWith('('))
                    {
                        parenCount++;
                        operands.Add(int.Parse(s[1..]));
                    }
                    else if (s.EndsWith(')'))
                    {
                        parenCount--;
                        operands.Add(int.Parse(s[0..^1]));
                    }
                    else if (int.TryParse(s, out var res))
                    {
                        operands.Add(res);
                    }
                    else
                    {
                        switch (s)
                        {
                            case "+":
                                operators.Add((a, b) => a + b);
                                break;
                            case "*":
                                operators.Add((a, b) => a * b);
                                break;
                        }
                    }
                }
            }
            return "";
        }

        public override string Part2()
        {
            return "";
        }
    }
}