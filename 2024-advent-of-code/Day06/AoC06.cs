using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day06;

public class AoC06 : AoC
{
    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        var parsedInput = ParseInput(input);

        var steps = CalculateSteps(parsedInput);
        Console.WriteLine($"Steps: {steps}");
    }

    private static int CalculateSteps(string[,] parsedInput)
    {
        var (y, x) = FindGuardPosition(parsedInput);

        var directions = new[]
        {
            (-1, 0), // up
            (0, 1),  // right
            (1, 0),  // down
            (0, -1)  // left
        };

        var currentDirection = 0;
        var path = new HashSet<(int, int)>();

        while (true)
        {
            var nextStep = (y + directions[currentDirection].Item1, x + directions[currentDirection].Item2);
            if (nextStep.Item1 < 0 || nextStep.Item1 >= parsedInput.GetLength(0) || nextStep.Item2 < 0 || nextStep.Item2 >= parsedInput.GetLength(1))
                break;

            if (parsedInput[nextStep.Item1, nextStep.Item2] == "#")
            {
                currentDirection = (currentDirection + 1) % 4;
            }
            else
            {
                y = nextStep.Item1;
                x = nextStep.Item2;
                path.Add((y, x));
            }
        }

        return path.Count;
    }

    private static (int y, int x) FindGuardPosition(string[,] parsedInput)
    {
        for (var i = 0; i < parsedInput.GetLength(0); i++)
        {
            for (var j = 0; j < parsedInput.GetLength(1); j++)
            {
                if (parsedInput[i, j] == "^")
                {
                    return (i, j);
                }
            }
        }

        throw new KeyNotFoundException("Guard not found");
    }

    private static string[,] ParseInput(string[] input)
    {
        var parsedInput = new string[input.Length, input[0].Length];
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                parsedInput[i, j] = input[i][j].ToString();
            }
        }

        return parsedInput;
    }
}