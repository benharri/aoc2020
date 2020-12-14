using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 14: <see href="https://adventofcode.com/2020/day/14">Docking Data</see>
    /// </summary>
    public sealed class Day14 : Day
    {
        private readonly Dictionary<ulong, ulong> _writesDict;

        public Day14() : base(14)
        {
            _writesDict = new Dictionary<ulong, ulong>();
        }

        public override string Part1()
        {
            ulong mask = 0, bits = 0;

            foreach (var line in Input)
            {
                if (line.StartsWith("mask = "))
                {
                    var str = line.Split("mask = ", 2)[1];
                    mask = bits = 0;
                    for (var i = 35; i >= 0; --i)
                    {
                        if (str[35 - i] == 'X')
                        {
                            mask |= (ulong) 1 << i;
                        }
                        else if (str[35 - i] == '1')
                        {
                            bits |= (ulong) 1 << i;
                        }
                    }
                }
                else
                {
                    var spl = line.Split(new[] {'[', ']', '='},
                            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                        .Skip(1)
                        .Select(ulong.Parse)
                        .ToArray();

                    _writesDict[spl[0]] = (spl[1] & mask) | bits;
                }
            }

            return $"{_writesDict.Aggregate<KeyValuePair<ulong, ulong>, ulong>(0, (current, w) => current + w.Value)}";
        }

        public override string Part2()
        {
            return "";
        }
    }
}
