using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace aoc2020.test;

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
    [DataRow(typeof(Day09), "138879426", "23761694")]
    [DataRow(typeof(Day10), "1980", "4628074479616")]
    [DataRow(typeof(Day11), "2303", "2057")]
    [DataRow(typeof(Day12), "1710", "62045")]
    [DataRow(typeof(Day13), "171", "539746751134958")]
    [DataRow(typeof(Day14), "17481577045893", "4160009892257")]
    [DataRow(typeof(Day15), "257", "8546398")]
    [DataRow(typeof(Day16), "19093", "5311123569883")]
    // [DataRow(typeof(Day17), "293", "1816")] // this one takes too long and i don't want to bother optimizing it
    [DataRow(typeof(Day18), "12918250417632", "171259538712010")]
    [DataRow(typeof(Day19), "160", "357")]
    //[DataRow(typeof(Day20), "21599955909991", "")]
    [DataRow(typeof(Day21), "2436", "dhfng,pgblcd,xhkdc,ghlzj,dstct,nqbnmzx,ntggc,znrzgs")]
    //[DataRow(typeof(Day22), "", "")]
    //[DataRow(typeof(Day23), "", "")]
    //[DataRow(typeof(Day24), "", "")]
    //[DataRow(typeof(Day25), "", "")]
    public void CheckAllDays(Type dayType, string part1, string part2)
    {
        // create day instance
        var s = Stopwatch.StartNew();
        var day = Activator.CreateInstance(dayType) as Day;
        s.Stop();
        Assert.IsNotNull(day, "failed to create day object");
        Console.WriteLine($"{s.ScaleMilliseconds()}ms elapsed in constructor");

        // part 1
        s.Reset();
        s.Start();
        var part1Actual = day!.Part1();
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
