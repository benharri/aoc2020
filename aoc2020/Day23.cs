namespace aoc2020;

/// <summary>
///     Day 23: <see href="https://adventofcode.com/2020/day/23" />
/// </summary>
public sealed class Day23 : Day
{
    private readonly Dictionary<long, long> cups = new();
    private readonly ImmutableList<long> initialCups;
    private readonly long[] move;
    private long current;

    public Day23() : base(23, "Crab Cups")
    {
        initialCups = Input.First().Select(c => long.Parse(c.ToString())).ToImmutableList();
        current = initialCups.First();
        move = new long[3];
    }

    private void DoMoves(int turns)
    {
        for (var turn = 0; turn < turns; turn++)
        {
            var dest = current - 1;
            if (dest == 0) dest = cups.Count;

            for (var i = 0; i <= 2; i++)
            {
                var id = cups[current];
                var removedNext = cups[id];
                cups.Remove(id);
                cups[current] = removedNext;

                move[i] = id;
            }

            while (move.Contains(dest))
            {
                dest--;
                if (dest == 0) dest = cups.Count + 3;
            }

            for (var i = 0; i <= 2; i++)
            {
                var id = cups[dest];
                cups[dest] = move[i];
                cups.Add(move[i], id);
                dest = cups[dest];
            }

            current = cups[current];
        }
    }

    public override string Part1()
    {
        for (var i = 0; i < initialCups.Count; i++)
            cups[initialCups[i]] = initialCups[(i + 1) % initialCups.Count];

        DoMoves(100);

        current = 1;
        var result = new StringBuilder();
        while (cups[current] != 1)
        {
            result.Append(cups[current]);
            current = cups[current];
        }

        return result.ToString();
    }

    public override string Part2()
    {
        cups.Clear();
        for (var i = 0; i < initialCups.Count; i++)
            cups[initialCups[i]] = initialCups[(i + 1) % initialCups.Count];

        // add a million cups
        cups[initialCups.Last()] = 10;
        for (var i = 10; i < 1_000_000; i++)
            cups.Add(i, i + 1);
        cups[1_000_000] = current = initialCups.First();

        DoMoves(10_000_000);

        return $"{(ulong)cups[1] * (ulong)cups[cups[1]]}";
    }
}
