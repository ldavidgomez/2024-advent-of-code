using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day02;

public class AoC02 : AoC
{
    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        /*
           7 6 4 2 1
           1 2 7 8 9
           9 7 6 2 1
           1 3 2 4 5
           8 6 4 4 1
           1 3 6 7 9
           Each row is a sequence of levels.
           A leve is safe if:
           - The levels are either all increasing or all decreasing.
           - Any two adjacent levels differ by at least one and at most three.
         */
        var levels = input.Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList();
        var safe = levels.Count(l => IsSafe(l));
        Console.WriteLine($"Part 1: {safe}");
        
        /*
           7 6 4 2 1
           1 2 7 8 9
           9 7 6 2 1
           1 3 2 4 5
           8 6 4 4 1
           1 3 6 7 9
           Each row is a sequence of levels.
           A leve is safe if:
           - The levels are either all increasing or all decreasing.
           - Any two adjacent levels differ by at least one and at most three.
           - if removing a single level from an unsafe report would make it safe, the report instead counts as safe
         */
        var tolerateSafe = levels.Count(l => IsTolerateSafe(l));
        Console.WriteLine($"Part 2: {tolerateSafe}");
    }

    private bool IsTolerateSafe(List<int> ints)
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

    private bool IsSafe(List<int> level)
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