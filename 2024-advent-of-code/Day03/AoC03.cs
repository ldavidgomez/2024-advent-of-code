using System.Text.RegularExpressions;
using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day03;

public partial class AoC03 : AoC
{
    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex MyRegex();

    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        var results = new List<Mul>();

        foreach (var match in input.SelectMany(line => MyRegex().Matches(line)).Select(match => match. Groups))
        {
            var firstInt = int.Parse(match[1].Value);
            var secondInt = int.Parse(match[2].Value);
            results.Add(new Mul(firstInt, secondInt));
            Console.WriteLine($"First integer: {firstInt}, Second integer: {secondInt}");
        }

        var sum = results.Sum(x => x.Result);
        Console.WriteLine($"Part 1: {sum}");
    }
}

public class Mul(int x, int y)
{
    public int Result { get; } = x * y;
}