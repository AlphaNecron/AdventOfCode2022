namespace AdventOfCode2022.Days;

public class Day1
{
    public static void Solve(string inp)
    {
        var sum = inp.Split("\n\n")
            .Select(f => f.Split('\n')
                .Select(num => int.Parse(num.Trim()))
                .Sum()).ToList();
        Console.WriteLine(sum.Max()); // part 1
        Console.WriteLine(sum.OrderByDescending(f => f).Take(3).Sum()); // part 2
    }
}