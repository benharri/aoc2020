using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    public sealed class Day7 : Day
    {
        private readonly Dictionary<string, IEnumerable<(int, string)?>> _rules;

        public Day7()
        {
            _rules = Input.Select(rule =>
                {
                    var spl = rule.Split(" contain", 2);
                    var outer = string.Join(' ', spl[0].Split(' ').Take(2));
                    var inner = spl[1].Split(", ").Select(ParseQuantity).Where(i => i != null);
                    return (outer, inner);
                })
                .ToDictionary(t => t.outer, t => t.inner);
        }

        public override int DayNumber => 7;

        private static (int, string)? ParseQuantity(string arg)
        {
            arg = arg.TrimStart();
            if (arg == "no other bags.") return null;
            var words = arg.Split(' ');
            return (int.Parse(words[0]), string.Join(' ', words[1..3]));
        }

        private int Weight(string node)
        {
            return 1 + _rules[node].Sum(i => i.Value.Item1 * Weight(i.Value.Item2));
        }

        public override string Part1()
        {
            // breadth-first search with Queue
            var start = new Queue<string>(new[] {"shiny gold"});
            var p = new HashSet<string>();
            string node;
            while (true)
            {
                node = start.Dequeue();
                foreach (var (container, contained) in _rules)
                    if (contained.Any(i => i.HasValue && i.Value.Item2 == node) && p.Add(container))
                        start.Enqueue(container);

                if (!start.Any()) break;
            }

            return $"{p.Count}";
        }

        public override string Part2()
        {
            return $"{Weight("shiny gold") - 1}";
        }
    }
}