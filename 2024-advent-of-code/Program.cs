using _2024_advent_of_code.Day01;
using _2024_advent_of_code.Day02;

namespace _2024_advent_of_code;

public static class Program
{
    static async Task Main(string[] args)
    {
        const string day = "Day02";
        const string inputPath = $"{day}/input.txt";
        const bool test = false;

        var aoc = new AoC02();
        await (test 
            ? aoc.Test(inputPath) 
            : aoc.Solve(inputPath));
    }
}