namespace _2024_advent_of_code.Common;

public abstract class AoC : IAoC
{
    public async Task Test(string inputPath)
    {
        var path = inputPath.Split(".");
        await Solve($"{path[0]}Test.{path[1]}");
    }

    public Task Solve(IEnumerable<string> input)
    {
        throw new NotImplementedException();
    }

    public abstract Task Solve(string inputPath);
    
    protected static async Task<string[]> GetInput(string inputPath)
    {
        return await File.ReadAllLinesAsync(inputPath);
    }
}