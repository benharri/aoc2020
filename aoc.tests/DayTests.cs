using System;
using System.Diagnostics;
using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class DayTests
    {
        [DataTestMethod]
        [DataRow(typeof(Day01), "751776", "42275090")]
        [DataRow(typeof(Day02), "556", "605")]
        [DataRow(typeof(Day03), "189", "1718180100")]
        [DataRow(typeof(Day04), "247", "145")]
        [DataRow(typeof(Day05), "878", "504")]
        [DataRow(typeof(Day06), "6273", "3254")]
        [DataRow(typeof(Day07), "169", "82372")]
        [DataRow(typeof(Day08), "1654", "833")]
        public void CheckAllDays(Type dayType, string part1, string part2)
        {
            // create day instance
            var s = Stopwatch.StartNew();
            var day = (Day) Activator.CreateInstance(dayType);
            s.Stop();
            Assert.IsNotNull(day, "failed to create day object");
            Console.WriteLine($"{s.ScaleMilliseconds()}ms elapsed in constructor");

            // part 1
            s.Reset();
            s.Start();
            var part1Actual = day.Part1();
            s.Stop();
            Console.WriteLine($"{s.ScaleMilliseconds()}ms elapsed in part1");
            Assert.AreEqual(part1, part1Actual, $"Incorrect answer for Day {day.DayNumber} Part1");

            // part 2
            s.Reset();
            s.Start();
            var part2Actual = day.Part2();
            s.Stop();
            Console.WriteLine($"{s.ScaleMilliseconds()}ms elapsed in part2");
            Assert.AreEqual(part2, part2Actual, $"Incorrect answer for Day {day.DayNumber} Part2");
        }
    }
}