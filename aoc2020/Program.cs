using aoc2020;
using System.Reflection;

var days = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.BaseType == typeof(Day))
    .Select(t => (Activator.CreateInstance(t) as Day)!)
    .OrderBy(d => d.DayNumber);

if (args.Length == 1 && int.TryParse(args[0], out var dayNum))
{
    var day = days.FirstOrDefault(d => d.DayNumber == dayNum);
    if (day != null) day.AllParts();
    else Console.WriteLine($"Day {dayNum} invalid or not yet implemented");
}
else
{
    foreach (var d in days) d.AllParts();
}
