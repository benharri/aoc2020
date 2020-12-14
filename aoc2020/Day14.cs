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
        public Day14() : base(14)
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
                        if (str[35 - i] == 'X')
                            mask |= (ulong) 1 << i;
                        else if (str[35 - i] == '1')
                            bits |= (ulong) 1 << i;
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
            var memory = new Dictionary<long, long>();
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
                    var value = long.Parse(spl[2]);
                    var addr = long.Parse(spl[0].Split(new[] {'[', ']'},
                        StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[1]);

                    var floats = new List<int>();
                    for (var i = 0; i < mask.Length; i++)
                        switch (mask[i])
                        {
                            case 'X':
                                floats.Add(i);
                                break;
                            case '1':
                                addr |= (long) 1 << (35 - i);
                                break;
                        }

                    if (floats.Any())
                    {
                        var combos = new List<int>();
                        combos.AddRange(floats);

                        foreach (var i in floats)
                        {
                            var newCombos = new List<int>();
                            foreach (var c in combos)
                            {
                                newCombos.Add(c | (1 << (35 - i)));
                                newCombos.Add(c & ~(1 << (35 - i)));
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

            return $"{memory.Sum(w => w.Value)}";
        }
    }
}