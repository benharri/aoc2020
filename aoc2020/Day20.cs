namespace aoc2020;

/// <summary>
///     Day 20: <see href="https://adventofcode.com/2020/day/20" />
/// </summary>
public sealed class Day20 : Day
{
    private readonly List<Tile> _allPermutations;
    private readonly List<Tile> _topLefts;

    public Day20() : base(20, "Jurassic Jigsaw")
    {
        var lines = new List<string>();
        var tiles = new List<Tile>();
        var currentTileId = 0;

        foreach (var line in Input)
            if (line.StartsWith("Tile "))
            {
                currentTileId = int.Parse(line.Split(' ', ':')[1]);
            }
            else if (line == "")
            {
                tiles.Add(new(currentTileId, lines.Select(l => l.ToCharArray()).ToArray()));
                lines.Clear();
            }
            else
            {
                lines.Add(line);
            }

        if (lines.Any()) tiles.Add(new(currentTileId, lines.Select(l => l.ToCharArray()).ToArray()));

        _allPermutations = tiles.SelectMany(t => t.AllPermutations()).ToList();
        _topLefts = _allPermutations
            .Where(t => !_allPermutations.Any(t2 => t.TileId != t2.TileId && t.LeftId == t2.RightId) &&
                        !_allPermutations.Any(t2 => t.TileId != t2.TileId && t.TopId == t2.BottomId))
            .ToList();
    }

    private int Roughness(Tile arg)
    {
        var seaMonster = new[]
        {
                "                  # ",
                "#    ##    ##    ###",
                " #  #  #  #  #  #   "
            }.Select(s => s.ToArray()).ToArray();

        const int seaMonsterWidth = 20;
        const int seaMonsterHeight = 3;
        const int seaMonsterTiles = 15;

        var placedTiles = new Dictionary<(int x, int y), Tile>();
        bool NotPlaced(Tile tile) => placedTiles!.Values.All(t => t.TileId != tile.TileId);
        char Grid(int i, int j) => placedTiles![(i / 8, j / 8)].Pixels[j % 8 + 1][i % 8 + 1];

        bool HasSeaMonster((int x, int y) location)
        {
            for (var j = 0; j < seaMonsterHeight; j++)
                for (var i = 0; i < seaMonsterWidth; i++)
                {
                    if (seaMonster![j][i] == ' ') continue;
                    if (Grid(location.x + i, location.y + j) != '#') return false;
                }

            return true;
        }

        placedTiles[(0, 0)] = arg;
        int x = 1, y = 0;
        while (true)
        {
            placedTiles.TryGetValue((x - 1, y), out var left);
            placedTiles.TryGetValue((x, y - 1), out var top);
            if (left == null && top == null) break;

            var firstMatch = _allPermutations
                .Where(t => (left is null || t.LeftId == left.RightId) &&
                            (top is null || t.TopId == top.BottomId))
                .Where(NotPlaced)
                .FirstOrDefault();

            if (firstMatch is not null)
            {
                placedTiles[(x, y)] = firstMatch;
                x++;
            }
            else
            {
                x = 0;
                y++;
            }
        }

        var gridWidth = placedTiles.Keys.Max(t => t.x) + 1;
        var gridHeight = placedTiles.Keys.Max(t => t.y) + 1;

        var seaMonsterCount = Enumerable.Range(0, gridWidth * 8 - seaMonsterWidth)
            .SelectMany(_ => Enumerable.Range(0, gridHeight * 8 - seaMonsterHeight), (i, j) => (i, j))
            .Count(HasSeaMonster);

        if (seaMonsterCount == 0) return 0;

        var roughness = 0;
        for (var j = 0; j < gridHeight; j++)
            for (var i = 0; i < gridWidth; i++)
                if (Grid(x, y) == '#')
                    roughness++;

        return roughness - seaMonsterCount * seaMonsterTiles;
    }

    public override string Part1()
    {
        return $"{_topLefts.Select(t => t.TileId).Distinct().Aggregate(1L, (acc, next) => acc * next)}";
    }

    public override string Part2()
    {
        return $"{_topLefts.Select(Roughness).First(r => r > 0)}";
    }

    private record Tile(int TileId, char[][] Pixels)
    {
        private const int Size = 10;
        internal int TopId => GetId(z => (z, 0));
        internal int BottomId => GetId(z => (z, Size - 1));
        internal int LeftId => GetId(z => (0, z));
        internal int RightId => GetId(z => (Size - 1, z));

        private int GetId(Func<int, (int x, int y)> selector)
        {
            return Enumerable.Range(0, Size)
                .Select(selector)
                .Select((c, i) => (Pixels[c.x][c.y] == '#' ? 1 : 0) << i)
                .Aggregate(0, (acc, next) => acc | next);
        }

        private Tile RotateClockwise()
        {
            return Transform((x, y, newPixels) => newPixels[x][Size - 1 - y] = Pixels[y][x]);
        }

        private Tile Flip()
        {
            return Transform((x, y, newPixels) => newPixels[y][Size - 1 - x] = Pixels[y][x]);
        }

        private Tile Transform(Action<int, int, char[][]> transformFunc)
        {
            var newPixels = Enumerable.Repeat(false, Size).Select(_ => new char[Size]).ToArray();

            for (var y = 0; y < Size; y++)
                for (var x = 0; x < Size; x++)
                    transformFunc(x, y, newPixels);

            return new(TileId, newPixels);
        }

        internal IEnumerable<Tile> AllPermutations()
        {
            var tile = this;
            for (var i = 1; i <= 8; i++)
            {
                yield return tile;
                if (i == 4) tile = Flip();
                else if (i == 8) yield break;
                tile = tile.RotateClockwise();
            }
        }

        public string Format()
        {
            return $"Tile {TileId}:\n{string.Join("\n", Pixels.Select(p => new string(p)))}";
        }
    }
}
