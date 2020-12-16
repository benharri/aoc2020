using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 14: <see href="https://adventofcode.com/2020/day/14" />
    /// </summary>
    public sealed class Day14 : Day
    {
        public Day14() : base(14, "Docking Data")
        {
        }

        public override string Part1()
        {
            var writes = new Dictionary<ulong, ulong>();
            ulong mask = 0, bits = 0;

            foreach (var line in Input)
                if (line.StartsWith("mask = "))
                {
                    var str = line.Split("mask = ", 2)[1];
                    mask = bits = 0;
                    for (var i = 35; i >= 0; --i)
                        switch (str[35 - i])
                        {
                            case 'X':
                                mask |= 1UL << i;
                                break;
                            case '1':
                                bits |= 1UL << i;
                                break;
                        }
                }
                else
                {
                    var spl = line.Split(new[] {'[', ']', '='},
                            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                        .Skip(1)
                        .Select(ulong.Parse)
                        .ToArray();

                    writes[spl[0]] = (spl[1] & mask) | bits;
                }

            return $"{writes.Aggregate<KeyValuePair<ulong, ulong>, ulong>(0, (current, w) => current + w.Value)}";
        }

        public override string Part2()
        {
            var memory = new Dictionary<ulong, ulong>();
            var mask = "";

            foreach (var line in Input)
            {
                var spl = line.Split(' ', 3, StringSplitOptions.TrimEntries);

                if (spl[0] == "mask")
                {
                    mask = spl[2];
                }
                else
                {
                    var value = ulong.Parse(spl[2]);
                    var addr = ulong.Parse(spl[0].Split(new[] {'[', ']'},
                        StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[1]);

                    var floats = new List<int>();
                    for (var i = 0; i < mask.Length; i++)
                        switch (mask[i])
                        {
                            case 'X':
                                floats.Add(i);
                                break;
                            case '1':
                                addr |= 1UL << (35 - i);
                                break;
                        }

                    if (floats.Any())
                    {
                        var combos = new List<ulong> {addr};

                        foreach (var i in floats)
                        {
                            var newCombos = new List<ulong>();
                            foreach (var c in combos)
                            {
                                newCombos.Add(c | (1UL << (35 - i)));
                                newCombos.Add(c & ~(1UL << (35 - i)));
                            }

                            combos = newCombos;
                        }

                        foreach (var c in combos)
                            memory[c] = value;
                    }
                    else
                    {
                        memory[addr] = value;
                    }
                }
            }

            return $"{memory.Aggregate<KeyValuePair<ulong, ulong>, ulong>(0, (current, w) => current + w.Value)}";
        }
    }
}