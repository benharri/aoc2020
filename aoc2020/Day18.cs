namespace aoc2020;

/// <summary>
///     Day 18: <see href="https://adventofcode.com/2020/day/18" />
/// </summary>
public sealed class Day18 : Day
{
    private readonly List<string> _expressions;

    public Day18() : base(18, "Operation Order")
    {
        _expressions = Input.Select(line => line.Replace(" ", "")).ToList();
    }

    private static long Calculate(string expr, Func<char, int> precedence)
    {
        var postfixNotation = new StringBuilder();
        var postfixStack = new Stack<char>();

        foreach (var c in expr)
            if (char.IsDigit(c))
            {
                postfixNotation.Append(c);
            }
            else if (c == '(')
            {
                postfixStack.Push(c);
            }
            else if (c == ')')
            {
                while (postfixStack.Count > 0 && postfixStack.Peek() != '(')
                    postfixNotation.Append(postfixStack.Pop());

                postfixStack.TryPop(out _);
            }
            else
            {
                while (postfixStack.Count > 0 && precedence(c) <= precedence(postfixStack.Peek()))
                    postfixNotation.Append(postfixStack.Pop());

                postfixStack.Push(c);
            }

        while (postfixStack.Count > 0)
            postfixNotation.Append(postfixStack.Pop());

        var expressionStack = new Stack<long>();

        foreach (var c in postfixNotation.ToString())
            if (char.IsDigit(c))
            {
                expressionStack.Push((long)char.GetNumericValue(c));
            }
            else
            {
                var a = expressionStack.Pop();
                var b = expressionStack.Pop();

                if (c == '+') expressionStack.Push(a + b);
                if (c == '*') expressionStack.Push(a * b);
            }

        return expressionStack.Pop();
    }

    public override string Part1()
    {
        return $"{_expressions.Sum(expr => Calculate(expr, c => c == '+' || c == '*' ? 1 : 0))}";
    }

    public override string Part2()
    {
        return $"{_expressions.Sum(expr => Calculate(expr, c => c switch { '+' => 2, '*' => 1, _ => 0 }))}";
    }
}
