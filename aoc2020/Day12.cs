namespace aoc2020;

/// <summary>
///     Day 12: <see href="https://adventofcode.com/2020/day/12" />
/// </summary>
public sealed class Day12 : Day
{
    public Day12() : base(12, "Rain Risk")
    {
    }

    private static void Swap(ref int x, ref int y)
    {
        (y, x) = (x, y);
    }

    private (int x, int y, int sx, int sy) ProcessInstructions()
    {
        // start facing east
        int x = 0, y = 0, dx = 1, dy = 0;
        int sx = 0, sy = 0, waypointX = 10, waypointY = -1;

        foreach (var instruction in Input)
        {
            var value = int.Parse(instruction[1..]);

            switch (instruction[0])
            {
                case 'N':
                    y -= value;
                    waypointY -= value;
                    break;
                case 'S':
                    y += value;
                    waypointY += value;
                    break;
                case 'E':
                    x += value;
                    waypointX += value;
                    break;
                case 'W':
                    x -= value;
                    waypointX -= value;
                    break;
                case 'L':
                    for (var i = 0; i < value / 90; ++i)
                    {
                        Swap(ref dx, ref dy);
                        Swap(ref waypointX, ref waypointY);
                        dy *= -1;
                        waypointY *= -1;
                    }

                    break;
                case 'R':
                    for (var i = 0; i < value / 90; ++i)
                    {
                        Swap(ref dx, ref dy);
                        Swap(ref waypointX, ref waypointY);
                        dx *= -1;
                        waypointX *= -1;
                    }

                    break;
                case 'F':
                    x += dx * value;
                    y += dy * value;
                    sx += waypointX * value;
                    sy += waypointY * value;
                    break;
                default: throw new InvalidOperationException(nameof(instruction));
            }
        }

        return (x, y, sx, sy);
    }

    public override string Part1()
    {
        var (x, y, _, _) = ProcessInstructions();
        return $"{Math.Abs(x) + Math.Abs(y)}";
    }

    public override string Part2()
    {
        var (_, _, sx, sy) = ProcessInstructions();
        return $"{Math.Abs(sx) + Math.Abs(sy)}";
    }
}
