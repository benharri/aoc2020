using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace aoc2020
{
    public abstract class Day
    {
        public abstract int DayNumber { get; }

        protected virtual IEnumerable<string> Input =>
            File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"input/day{DayNumber}.in"));

        public abstract string Part1();
        public abstract string Part2();

        public virtual void AllParts(bool verbose = true)
        {
            Console.WriteLine($"Day {DayNumber}:");
            var s = new Stopwatch();

            s.Start();
            var part1 = Part1();
            s.Stop();
            Console.WriteLine(part1);

            if (verbose)
                Console.WriteLine($"{s.ElapsedMilliseconds}ms elapsed");

            s.Reset();

            s.Start();
            var part2 = Part2();
            s.Stop();
            Console.WriteLine(part2);

            if (verbose)
                Console.WriteLine($"{s.ElapsedMilliseconds}ms elapsed");

            Console.WriteLine();
        }
    }
}