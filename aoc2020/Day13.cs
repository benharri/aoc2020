using System.Linq;

namespace aoc2020
{
    /// <summary>
    ///     Day 13: <see href="https://adventofcode.com/2020/day/13">Shuttle Search</see>
    /// </summary>
    public sealed class Day13 : Day
    {
        private readonly long[] _buses;
        private readonly long _earliest;
        private readonly string[] _fullSchedule;

        public Day13() : base(13)
        {
            _earliest = long.Parse(Input.First());
            _fullSchedule = Input.Last().Split(',');
            _buses = _fullSchedule.Where(c => c != "x").Select(long.Parse).ToArray();
        }

        public override string Part1()
        {
            for (var i = _earliest;; i++)
                if (_buses.Any(b => i % b == 0))
                {
                    var bus = _buses.First(b => i % b == 0);
                    return $"{bus * (i - _earliest)}";
                }
        }

        public override string Part2()
        {
            var i = 0;
            long result = 1, multiplier = 1;

            foreach (var id in _fullSchedule)
            {
                if (id != "x")
                {
                    var increment = long.Parse(id);
                    while (((result += multiplier) + i) % increment != 0)
                    {
                    }

                    multiplier *= increment;
                }

                i++;
            }

            return $"{result}";
        }
    }
}