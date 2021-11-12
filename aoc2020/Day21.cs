namespace aoc2020;

/// <summary>
///     Day 21: <see href="https://adventofcode.com/2020/day/21" />
/// </summary>
public sealed class Day21 : Day
{
    private readonly IEnumerable<(string[] Allergens, string[] Ingredients)> _parsedFoods;
    private readonly IEnumerable<(string Allergen, string Ingredient)> _dangerousFoods;

    public Day21() : base(21, "Allergen Assessment")
    {
        _parsedFoods = Input.Select(line => line.TrimEnd(')').Split(" (contains "))
            .Select(split => (Allergens: split[1].Split(", "), Ingredients: split[0].Split(' ')));
        
        _dangerousFoods = _parsedFoods
            .SelectMany(i => i.Allergens.Select(Allergen => (Allergen, i.Ingredients)))
            .GroupBy(
                pair => pair.Allergen,
                pair => pair.Ingredients.Select(i => i),
                // group by intersection of ingredients
                (Allergen, collection) =>
                    (Allergen, Ingredients: collection.Aggregate((acc, it) => acc.Intersect(it)))
            )
            .OrderBy(food => food.Ingredients.Count())
            .Aggregate(
                Enumerable.Empty<(string Allergen, string Ingredient)>(),
                (poisons, pair) =>
                    poisons.Concat(new[] {(
                        allergen: pair.Allergen,
                        ingredient: pair.Ingredients.Except(poisons.Select(i => i.Ingredient)).First()
                    )})
            );
    }

    public override string Part1()
    {
        var part1 = _parsedFoods
            .SelectMany(i => i.Ingredients)
            .Count(i => !_dangerousFoods.Select(t => t.Ingredient).Contains(i));
        
        return $"{part1}";
    }

    public override string Part2()
    {
        var part2 = _dangerousFoods
            .OrderBy(i => i.Allergen)
            .Select(i => i.Ingredient);
        
        return $"{string.Join(',', part2)}";
    }
}
