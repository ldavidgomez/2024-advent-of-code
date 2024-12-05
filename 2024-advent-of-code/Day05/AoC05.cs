using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day05;

public class AoC05 : AoC
{
    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        var parsedInput = ParseInput(input);

        var validUpdates = GetValidUpdates(parsedInput.rules, parsedInput.updates);
        var total = GetSumMiddleNumber(validUpdates);
        Console.WriteLine($"Sum of middle numbers: {total}");
    }

    private static int GetSumMiddleNumber(int[][] validUpdates)
    {
        return validUpdates.Sum(update => update[update.Length / 2]);
    }

    private static int[][] GetValidUpdates(List<(int, int)> rules, string[] updates)
    {
        return updates
            .Select(update => update.Split(',').Select(int.Parse).ToArray())
            .Where(parts => parts.Select((current, index) => new { current, index }).All(pair =>
                CheckPrevious(parts.Take(pair.index).ToList(), pair.current, rules) &&
                CheckNext(parts.Skip(pair.index + 1).ToList(), pair.current, rules)))
            .ToArray();
    }

    private static bool CheckNext(List<int> next, int current, List<(int, int)> rules)
    {
        return next.TrueForAll(n => rules.Contains((current, n)));
    }

    private static bool CheckPrevious(List<int> previous, int current, List<(int, int)> rules)
    {
        return previous.TrueForAll(prev => rules.Contains((prev, current)));
    }

    private static (List<(int, int)> rules, string[] updates) ParseInput(string[] input)
    {
        var rules = new List<(int, int)>();
        var updates = new List<string>();
        var isAfterBlankLine = false;

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                isAfterBlankLine = true;
                continue;
            }

            if (isAfterBlankLine)
            {
                updates.Add(line);
            }
            else
            {
                var parts = line.Split('|');
                rules.Add((int.Parse(parts[0]), int.Parse(parts[1])));
            }
        }

        return (rules, updates.ToArray());
    }
}