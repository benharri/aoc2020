using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace aoc2020
{
    public abstract class Day
    {
        public abstract int DayNumber { get; }
        public virtual IEnumerable<string> Input =>
            File.ReadLines($"input/day{DayNumber}.in");

        public abstract string Part1();
        public abstract string Part2();

        public virtual void AllParts(bool verbose = false)
        {
            Console.WriteLine($"Day {DayNumber}:");
            var s = new Stopwatch();

            if (verbose)
            {
                s.Start();
            }

            var part1 = Part1();

            if (verbose) 
            {
                s.Stop();
                Console.WriteLine($"Part 1 elapsed ticks: {s.ElapsedTicks}");
            }

            Console.WriteLine(part1);

            if (verbose)
            {
                s.Reset();
                s.Start();
            }

            var part2 = Part2();

            if (verbose)
            {
                s.Stop();
                Console.WriteLine($"Part 2 elapsed ticks: {s.ElapsedTicks}");
            }

            Console.WriteLine(part2);
            Console.WriteLine();
        }
    }
}


