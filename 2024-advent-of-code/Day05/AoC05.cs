using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day05;

public class AoC05 : AoC
{
    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        var parsedInput = ParseInput(input);

        var validUpdates = GetValidUpdates(parsedInput.rules, parsedInput.updates);
        
        var totalValid = GetSumMiddleNumber(validUpdates);
        Console.WriteLine($"Sum of middle numbers: {totalValid}");
        
        var invalidUpdates = GetInvalidUpdates(parsedInput.updates, validUpdates);
        var fixedUpdates = FixInvalidUpdates(parsedInput.rules, invalidUpdates);
        
        var totalInvalid = GetSumMiddleNumber(fixedUpdates);
        Console.WriteLine($"Sum of middle numbers after fixing invalid updates: {totalInvalid}");
    }

    private static int[][] FixInvalidUpdates(List<(int, int)> rules, int[][] invalidUpdates)
    {
        foreach (var subArray in invalidUpdates)
        {
            BubbleSort(subArray, rules);
        }

        return invalidUpdates;
    }

    private static void BubbleSort(int[] updates, List<(int, int)> rules)
    {
        var updatesLength = updates.Length;
        bool swapped;

        do
        {
            swapped = false;
            for (var i = 0; i < updatesLength - 1; i++)
            {
                if (!ShouldSwap(updates[i], updates[i + 1], rules)) continue;
                (updates[i], updates[i + 1]) = (updates[i + 1], updates[i]);
                swapped = true;
            }
        } while (swapped);
    }

    private static bool ShouldSwap(int a, int b, List<(int, int)> rules)
    {
        return rules.Exists(rule => rule.Item1 == b && rule.Item2 == a);
    }

    private static int[][] GetInvalidUpdates(string[] parsedInputUpdates, int[][] validUpdates)
    {
        return parsedInputUpdates
            .Select(update => update.Split(',').Select(int.Parse).ToArray())
            .Where(parts => !Array.Exists(validUpdates, valid => valid.SequenceEqual(parts)))
            .ToArray();
    }

    private static int GetSumMiddleNumber(int[][] validUpdates)
    {
        return validUpdates.Sum(update => update[update.Length / 2]);
    }

    private static int[][] GetValidUpdates(List<(int, int)> rules, string[] updates)
    {
        return updates
            .Select(update => update.Split(',').Select(int.Parse).ToArray())
            .Where(parts => parts.Select((current, index) => new { current, index })
                .All(pair => 
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