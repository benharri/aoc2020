namespace aoc2020;

/// <summary>
///     Day 7: <see href="https://adventofcode.com/2020/day/7" />
/// </summary>
public sealed class Day07 : Day
{
    private readonly Dictionary<string, IEnumerable<(int, string)?>> _rules;

    public Day07() : base(7, "Handy Haversacks")
    {
        _rules = Input.Select(rule =>
            {
                var spl = rule.Split(" bags contain ", 2);
                var outer = string.Join(' ', spl[0].Split(' ').Take(2));
                var inner = spl[1].Split(", ").Select(ParseQuantity).Where(i => i != null);
                return (outer, inner);
            })
            .ToDictionary(t => t.outer, t => t.inner);
    }

    private static (int, string)? ParseQuantity(string arg)
    {
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
        var start = new Queue<string>(new[] { "shiny gold" });
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
