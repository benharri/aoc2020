using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 16: <see href="https://adventofcode.com/2020/day/16">Ticket Translation</see>
    /// </summary>
    public sealed class Day16 : Day
    {
        private List<List<int>> _tickets;
        private Dictionary<string, List<Range>> _rules;

        public Day16() : base(16)
        {
            _tickets = new List<List<int>>();
            _rules = new Dictionary<string, List<Range>>();

            foreach (var line in Input)
            {
                var spl = line.Split(": ", 2, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (spl.Length == 2)
                {
                    var rule = spl[1].Split(" or ").Select(s =>
                    {
                        var r = s.Split('-').Select(int.Parse).ToList();
                        return new Range(r[0], r[1]);
                    }).ToList();

                    _rules.Add(spl[0], rule);
                }
                else
                {
                    spl = line.Split(',');
                    if (spl.Length > 1)
                        _tickets.Add(spl.Select(int.Parse).ToList());
                }
            }
        }

        public override string Part1()
        {
            return
                $"{_tickets.Skip(1).SelectMany(t => t).Where(t => !_rules.Values.SelectMany(r => r).Any(r => t >= r.Start.Value && t <= r.End.Value)).Sum()}";
        }

        public override string Part2()
        {
            return "";
        }
    }
}
