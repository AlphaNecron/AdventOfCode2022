namespace AdventOfCode2022.Days;

public class Day4
{
    public static void Solve(string inp)
    {
        long countPart1 = 0, countPart2 = 0;

        int[] GetRange(string p)
        {
            var parts = p.Split('-').Select(int.Parse).ToArray();
            return Enumerable.Range(parts[0], parts[1] - parts[0] + 1).ToArray();
        }

        foreach (var pair in inp.Split('\n'))
        {
            var pairs = pair.Split(',');
            int[] r1 = GetRange(pairs[0]), r2 = GetRange(pairs[1]);
            var intersection = r1.Intersect(r2).ToArray();
            if (intersection.Length == r1.Length || intersection.Length == r2.Length)
                countPart1++;
            if (intersection.Any())
                countPart2++;
        }

        Console.WriteLine(countPart1);
        Console.WriteLine(countPart2);
    }
}