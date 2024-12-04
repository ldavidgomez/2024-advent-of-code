using _2024_advent_of_code.Day01;
using _2024_advent_of_code.Day02;
using _2024_advent_of_code.Day03;
using _2024_advent_of_code.Day04;

namespace _2024_advent_of_code;

public static class Program
{
    static async Task Main(string[] args)
    {
        await Day04();
    }

    private static async Task Day01()
    {
        const string inputPath = $"Day01/input.txt";
        const bool test = false;

        var aoc = new AoC01();
        await (test 
            ? aoc.Test(inputPath) 
            : aoc.Solve(inputPath));
    }
    
    private static async Task Day02()
    {
        const string inputPath = $"Day02/input.txt";
        const bool test = true;

        var aoc = new AoC02();
        await (test 
            ? aoc.Test(inputPath) 
            : aoc.Solve(inputPath));
    }
    
    private static async Task Day03()
    {
        const string inputPath = $"Day03/input.txt";
        const bool test = false;

        var aoc = new AoC03();
        await (test 
            ? aoc.Test(inputPath) 
            : aoc.Solve(inputPath));
    }
    
    private static async Task Day04()
    {
        const string inputPath = $"Day04/input.txt";
        const bool test = false;

        var aoc = new AoC04();
        await (test 
            ? aoc.Test(inputPath) 
            : aoc.Solve(inputPath));
    }
}