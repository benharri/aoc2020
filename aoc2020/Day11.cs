namespace aoc2020;

/// <summary>
///     Day 11: <see href="https://adventofcode.com/2020/day/11" />
/// </summary>
public sealed class Day11 : Day
{
    public Day11() : base(11, "Seating System")
    {
    }

    public override string Part1()
    {
        var prev = new LifeGame(Input);

        while (true)
        {
            var next = prev.StepPart1();
            var same = true;
            for (var i = 0; i < next.Grid.Length; i++)
                if (!next.Grid[i].SequenceEqual(prev.Grid[i]))
                {
                    same = false;
                    break;
                }

            if (same) break;
            prev = next;
        }

        return $"{prev.TotalSeated}";
    }

    public override string Part2()
    {
        var prev = new LifeGame(Input);
        while (true)
        {
            var next = prev.StepPart2();
            var same = true;
            for (var i = 0; i < next.Grid.Length; i++)
                if (!next.Grid[i].SequenceEqual(prev.Grid[i]))
                {
                    same = false;
                    break;
                }

            if (same) break;
            prev = next;
        }

        return $"{prev.TotalSeated}";
    }

    private class LifeGame
    {
        private int _h, _w;
        public char[][] Grid;

        public LifeGame(IEnumerable<string> input)
        {
            Grid = input.Select(line => line.ToCharArray()).ToArray();
            _h = Grid.Length;
            _w = Grid[0].Length;
        }

        private LifeGame()
        {
        }

        public int TotalSeated =>
            Grid.Sum(l => l.Count(c => c == '#'));

        private void PrintBoard()
        {
            Console.Clear();
            foreach (var line in Grid)
                Console.WriteLine(line);
        }

        public LifeGame StepPart1()
        {
            var next = new LifeGame { _h = _h, _w = _w, Grid = Grid.Select(s => s.ToArray()).ToArray() };
            for (var y = 0; y < _h; y++)
                for (var x = 0; x < _w; x++)
                    next.Grid[y][x] = Grid[y][x] switch
                    {
                        'L' when CountAdjacent(y, x) == 0 => '#',
                        '#' when CountAdjacent(y, x) >= 4 => 'L',
                        _ => Grid[y][x]
                    };

            // next.PrintBoard();
            return next;
        }

        private char At(int y, int x)
        {
            return x < 0 || y < 0 || x >= _w || y >= _h ? '.' : Grid[y][x];
        }

        private int CountAdjacent(int y, int x)
        {
            return new[]
            {
                    At(y - 1, x - 1), At(y - 1, x + 0), At(y - 1, x + 1),
                    At(y + 0, x - 1), At(y + 0, x + 1),
                    At(y + 1, x - 1), At(y + 1, x + 0), At(y + 1, x + 1)
                }.Count(c => c == '#');
        }

        public LifeGame StepPart2()
        {
            var next = new LifeGame { _h = _h, _w = _w, Grid = Grid.Select(s => s.ToArray()).ToArray() };
            for (var y = 0; y < _h; y++)
                for (var x = 0; x < _w; x++)
                    next.Grid[y][x] = Grid[y][x] switch
                    {
                        'L' when CanSee(y, x) == 0 => '#',
                        '#' when CanSee(y, x) >= 5 => 'L',
                        _ => Grid[y][x]
                    };

            // next.PrintBoard();
            return next;
        }

        private int CanSee(int y, int x)
        {
            return new[]
            {
                    TraceRay(y, x, -1, -1), TraceRay(y, x, -1, +0), TraceRay(y, x, -1, +1),
                    TraceRay(y, x, +0, -1), TraceRay(y, x, +0, +1),
                    TraceRay(y, x, +1, -1), TraceRay(y, x, +1, +0), TraceRay(y, x, +1, +1)
                }.Count(c => c == '#');
        }

        private char TraceRay(int y, int x, int dy, int dx)
        {
            y += dy;
            x += dx;
            while (y >= 0 && y < _h && x >= 0 && x < _w)
            {
                if (Grid[y][x] != '.') return Grid[y][x];
                y += dy;
                x += dx;
            }

            return '.';
        }
    }
}
