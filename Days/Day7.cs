namespace AdventOfCode2022.Days;

public class Day7
{
    public static void Solve(string inp)
    {
        var lines = inp.Split('\n');
        var path = "";
        var paths = new Dictionary<string, int>();
        const int
            totalSpace = 70_000_000,
            requiredSpace = 30_000_000;
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (!line.StartsWith('$')) continue;
            var parts = line.Split(' ');
            var command = parts.ElementAt(1);
            var args = parts.Length > 2 ? parts.Last() : "";
            switch (command)
            {
                case "cd":
                    path = Path.GetFullPath(Path.Combine(path, args));
                    break;
                case "ls":
                {
                    var output = lines.Skip(i + 1).TakeWhile(f => !f.StartsWith('$'));
                    var sizes = output.Where(f => f.Split(' ').First().All(char.IsDigit))
                        .Sum(f => int.Parse(f.Split(' ').First()));
                    paths.TryAdd(path, sizes);
                    break;
                }
            }
        }

        foreach (var p1 in paths)
        foreach (var p2 in paths.Where(p2 => p1.Key != p2.Key).Where(p2 => p2.Key.StartsWith(p1.Key)))
            paths[p1.Key] += p2.Value;
        // part 1 result
        Console.WriteLine(paths.Where(f => f.Value <= 100_000).Sum(f => f.Value));
        // part 2 solution
        var occupiedSpace = paths["/"];
        var requiredFreeSpace = requiredSpace - (totalSpace - occupiedSpace);
        // part 2 result
        Console.WriteLine(paths.Where(f => f.Value >= requiredFreeSpace).Min(f => f.Value));
    }
}