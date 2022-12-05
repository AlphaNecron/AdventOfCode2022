namespace AdventOfCode2022.Days;

public class Day3
{
    public static void Solve(string inp)
    {
        byte GetIndex(char c)
        {
            if (char.IsUpper(c))
                return (byte) (c % 32 + 26);
            return (byte) (c % 32);
        }

        char[] GetCommon(string rucksack)
        {
            var len = rucksack.Length / 2;
            string firstHalf = rucksack[..len], secondHalf = rucksack[len..];
            return firstHalf.Intersect(secondHalf).ToArray();
        }

        IEnumerable<string[]> Split(string[] arr)
        {
            for (var i = 0; i < Math.Ceiling(arr.Length / 3d); i++)
                yield return arr.Skip(i * 3).Take(3).ToArray();
        }

        var lines = inp.Split('\n');
        var sum = lines.Sum(rucksack => GetCommon(rucksack).Sum(c => GetIndex(c)));
        var groups = Split(lines).ToArray();
        var sumOfGroups = groups.Sum(group => group[0].Intersect(group[1]).Intersect(group[2]).Sum(c => GetIndex(c)));
        Console.WriteLine(sum);
        Console.WriteLine(sumOfGroups);
    }
}