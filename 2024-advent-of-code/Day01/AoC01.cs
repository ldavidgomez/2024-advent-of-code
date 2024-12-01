using _2024_advent_of_code.Common;

namespace _2024_advent_of_code.Day01;

public class AoC01 : AoC
{
    private List<int> _left = [];
    private List<int> _right = [];
    
    public override async Task Solve(string inputPath)
    {
        var input = await GetInput(inputPath);
        var values = input.Select(line => line.Split("   ").Select(int.Parse).ToList()).ToList();
        _left = values.Select(v => v[0]).OrderBy(x => x).ToList();
        _right = values.Select(v => v[1]).OrderBy(x => x).ToList();

        Console.WriteLine($"Part 1: {GetDistance()}");
        Console.WriteLine($"Part 2: {GetSimilarity()}");
    }

    private int GetDistance()
    {
        return _left.Zip(_right, (l, r) => Math.Abs(l - r)).Sum();
    }

    private int GetSimilarity()
    {
        return _left.Sum(l => _right.Count(r => r == l) * l);
    }
}
