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
        private readonly Dictionary<string, List<Range>> _rules;
        private readonly List<List<int>> _tickets;

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
            var allValues = _tickets.Skip(1).SelectMany(t => t);
            var allRules = _rules.Values.SelectMany(r => r);
            return
                $"{allValues.Where(t => !allRules.Any(r => r.Contains(t))).Sum()}";
        }

        public override string Part2()
        {
            var ticketFields = _tickets
                // valid tickets
                .Where(ticket => ticket
                    .All(t => _rules.Values
                        .SelectMany(r => r)
                        .Any(r => r.Contains(t))))
                // group by index
                .SelectMany(inner => inner.Select((item, index) => new {item, index}))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => g.ToList())
                .Select((val, i) => new {Value = val, Index = i})
                .ToList();

            var matchedRules = _rules
                // find matching rules and indices
                .SelectMany(x => ticketFields
                    .Where(y => y.Value.All(z => x.Value.Any(r => r.Contains(z))))
                    .Select(y => (x.Key, y.Index))
                    .ToList())
                .ToList();

            matchedRules.Sort((a, b) =>
                matchedRules.Count(x => x.Key == a.Key) - matchedRules.Count(x => x.Key == b.Key));

            while (matchedRules.Any(x => matchedRules.Count(y => y.Key == x.Key) > 1))
                foreach (var (key, index) in matchedRules.Where(y =>
                        matchedRules.Count(z => z.Key == y.Key) == 1 &&
                        matchedRules.Count(z => z.Index == y.Index) > 1))
                    // filter matches by index
                    matchedRules = matchedRules
                        .Where(x => x.Index != index || x.Key == key)
                        .ToList();

            var departureFields = matchedRules.Where(r => r.Key.StartsWith("departure"));

            return
                $"{departureFields.Aggregate(1L, (l, match) => l * _tickets.First()[match.Index])}";
        }
    }
}