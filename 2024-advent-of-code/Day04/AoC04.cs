using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day04;

public class AoC04 : AoC
{
    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        var parsedInput = InitializeGrid(input);
        var count = CountOccurrences(parsedInput, "XMAS");
        Console.WriteLine($"Number of times XMAS appears: {count}");
    }
    
    private static string[,] InitializeGrid(string[] input)
    {
        var grid = new string[input.Length, input[0].Length];
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input[0].Length; j++)
            {
                grid[i, j] = input[i][j].ToString();
            }
        }

        return grid;
    }

    private static int CountOccurrences(string[,] grid, string word)
    {
        var count = 0;
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);
        var wordLength = word.Length;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (j <= cols - wordLength && IsMatch(grid, word, i, j, 0, 1)) count++;
                if (j >= wordLength - 1 && IsMatch(grid, word, i, j, 0, -1)) count++;
                if (i <= rows - wordLength && IsMatch(grid, word, i, j, 1, 0)) count++;
                if (i >= wordLength - 1 && IsMatch(grid, word, i, j, -1, 0)) count++;
                if (i <= rows - wordLength && j <= cols - wordLength && IsMatch(grid, word, i, j, 1, 1)) count++;
                if (i >= wordLength - 1 && j >= wordLength - 1 && IsMatch(grid, word, i, j, -1, -1)) count++;
                if (i <= rows - wordLength && j >= wordLength - 1 && IsMatch(grid, word, i, j, 1, -1)) count++;
                if (i >= wordLength - 1 && j <= cols - wordLength && IsMatch(grid, word, i, j, -1, 1)) count++;
            }
        }

        return count;
    }

    private static bool IsMatch(string[,] grid, string word, int startX, int startY, int stepX, int stepY)
    {
        for (var k = 0; k < word.Length; k++)
        {
            if (grid[startX + k * stepX, startY + k * stepY][0] != word[k])
                return false;
        }
        return true;
    }
}