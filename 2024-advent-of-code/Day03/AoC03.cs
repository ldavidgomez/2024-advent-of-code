using System.Text.RegularExpressions;
using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day03;

public partial class AoC03 : AoC
{
    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex MulRegex();
    
    [GeneratedRegex(@"do\(\)")]
    private static partial Regex DoRegex();
    
    [GeneratedRegex(@"don't\(\)")]
    private static partial Regex DontRegex();

    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        var results = new List<Mul>();

        foreach (var match in input.SelectMany(line => MulRegex().Matches(line)).Select(match => match. Groups))
        {
            var firstInt = int.Parse(match[1].Value);
            var secondInt = int.Parse(match[2].Value);
            results.Add(new Mul(firstInt, secondInt));
        }

        var sum = results.Sum(x => x.Result);
        Console.WriteLine($"Part 1: {sum}");
        
        var inputOneLine = string.Join("", input);
        
        var total = 0;
        var allMul = MulRegex().Matches(inputOneLine).Select(match => new Mul(match.Groups, "Mul", match.Index))
            .Concat(DoRegex().Matches(inputOneLine).Select(x => new Mul(0, 0, "Do", x.Index)))
            .Concat(DontRegex().Matches(inputOneLine).Select(x => new Mul(0, 0, "Dont", x.Index)))
            .OrderBy(x => x.Position)
            .ToList();
        
        var enable = true;
        foreach (var mul in allMul)
        {
            switch (mul.Type)
            {
                case "Do":
                    enable = true;
                    break;
                case "Dont":
                    enable = false;
                    break;
                case "Mul" when enable:
                    total += mul.Result;
                    break;
            }
        }

        Console.WriteLine($"Part 2: {total}");
    }
}

public class Mul(int x, int y, string? type = null, int position = 0)
{ 
    public string? Type { get; } = type;
    public int Position { get; } = position;
    public int Result { get; } = x * y;

    public Mul(GroupCollection group, string? type = null, int position = 0) 
        : this(int.Parse(group[1].Value), int.Parse(group[2].Value), type, position)
    {
        Result = int.Parse(group[1].Value) * int.Parse(group[2].Value);
    }
}