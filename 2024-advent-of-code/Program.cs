using _2024_advent_of_code.Day01;

namespace _2024_advent_of_code;

public static class Program
{
    static async Task Main(string[] args)
    {
        const string day = "Day01";
        const string inputPath = $"{day}/input.txt";
        const bool test = true;

        var aoc = new AoC01();
        await (test 
            ? aoc.Test(inputPath) 
            : aoc.Solve(inputPath));
    }
}