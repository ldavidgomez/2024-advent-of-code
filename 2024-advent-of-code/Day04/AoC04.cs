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
        
        count = CountXmasOccurrences(parsedInput);
        Console.WriteLine($"Number of times X-MAS appears: {count}");
    }
    
    private static string[,] InitializeGrid(string[] input)
    {
        var grid = new string[input.Length, input[0].Length];
        for (var x = 0; x < input.Length; x++)
        {
            for (var y = 0; y < input[0].Length; y++)
            {
                grid[x, y] = input[x][y].ToString();
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

        for (var x = 0; x < rows; x++)
        {
            for (var y = 0; y < cols; y++)
            {
                if (y <= cols - wordLength && IsMatch(grid, word, x, y, 0, 1)) count++;
                if (y >= wordLength - 1 && IsMatch(grid, word, x, y, 0, -1)) count++;
                if (x <= rows - wordLength && IsMatch(grid, word, x, y, 1, 0)) count++;
                if (x >= wordLength - 1 && IsMatch(grid, word, x, y, -1, 0)) count++;
                if (x <= rows - wordLength && y <= cols - wordLength && IsMatch(grid, word, x, y, 1, 1)) count++;
                if (x >= wordLength - 1 && y >= wordLength - 1 && IsMatch(grid, word, x, y, -1, -1)) count++;
                if (x <= rows - wordLength && y >= wordLength - 1 && IsMatch(grid, word, x, y, 1, -1)) count++;
                if (x >= wordLength - 1 && y <= cols - wordLength && IsMatch(grid, word, x, y, -1, 1)) count++;
            }
        }

        return count;
    }

    private static bool IsMatch(string[,] grid, string word, int startX, int startY, int stepX, int stepY)
    {
        for (var i = 0; i < word.Length; i++)
        {
            if (grid[startX + i * stepX, startY + i * stepY][0] != word[i])
                return false;
        }
        return true;
    }
    
    private static int CountXmasOccurrences(string[,] grid)
    {
        var count = 0;
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);

        for (var x = 1; x < rows - 1; x++)
        {
            for (var y = 1; y < cols - 1; y++)
            {
                if (IsXmas(grid, x, y))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static bool IsXmas(string[,] grid, int x, int y)
    {
        return (grid[x - 1, y - 1] == "M" && grid[x - 1, y + 1] == "M" &&
                grid[x, y] == "A" &&
                grid[x + 1, y - 1] == "S" && grid[x + 1, y + 1] == "S")
               || 
               (grid[x - 1, y - 1] == "M" && grid[x - 1, y + 1] == "S" &&
                grid[x, y] == "A" &&
                grid[x + 1, y - 1] == "M" && grid[x + 1, y + 1] == "S")
               || 
               (grid[x - 1, y - 1] == "S" && grid[x - 1, y + 1] == "S" &&
                grid[x, y] == "A" && 
                grid[x + 1, y - 1] == "M" && grid[x + 1, y + 1] == "M")
               || 
               (grid[x - 1, y - 1] == "S" && grid[x - 1, y + 1] == "M" &&
                grid[x, y] == "A" &&
                grid[x + 1, y - 1] == "S" && grid[x + 1, y + 1] == "M");
    }
}