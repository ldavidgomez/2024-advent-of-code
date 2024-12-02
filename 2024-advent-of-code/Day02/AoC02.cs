using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day02;

public class AoC02 : AoC
{
    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        var levels = input.Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList();
        var safe = levels.Count(IsSafe);
        Console.WriteLine($"Part 1: {safe}");
        
        var tolerateSafe = levels.Count(IsTolerateSafe);
        Console.WriteLine($"Part 2: {tolerateSafe}");
    }

    private static bool IsTolerateSafe(List<int> ints)
    {
        for (var i = 0; i < ints.Count; i++)
        {
            var copy = ints.ToList();
            copy.RemoveAt(i);
            if (IsSafe(copy))
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsSafe(List<int> level)
    {
        var increasing = level.Zip(level.Skip(1), (a, b) => a < b).All(x => x);
        var decreasing = level.Zip(level.Skip(1), (a, b) => a > b).All(x => x);
        if (!increasing && !decreasing)
        {
            return false;
        }
        return level.Zip(level.Skip(1), (a, b) => Math.Abs(a - b) <= 3).All(x => x);
    }
}