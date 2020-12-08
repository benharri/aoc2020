using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace aoc2020
{
    public abstract class Day
    {
        protected Day(int dayNumber)
        {
            DayNumber = dayNumber;
        }

        public int DayNumber { get; protected set; }

        protected virtual IEnumerable<string> Input =>
            File.ReadLines(FileName);

        protected virtual string FileName =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"input/day{DayNumber}.in");

        public abstract string Part1();
        public abstract string Part2();

        public virtual void AllParts(bool verbose = true)
        {
            Console.WriteLine($"Day {DayNumber}:");
            var s = Stopwatch.StartNew();
            var part1 = Part1();
            s.Stop();
            Console.Write($"Part1: {part1,-14} ");
            Console.WriteLine(verbose ? $"{s.ScaleMilliseconds()}ms elapsed" : "");

            s.Reset();

            s.Start();
            var part2 = Part2();
            s.Stop();
            Console.Write($"Part2: {part2,-14} ");
            Console.WriteLine(verbose ? $"{s.ScaleMilliseconds()}ms elapsed" : "");

            Console.WriteLine();
        }
    }
}