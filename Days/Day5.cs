using System.Text.RegularExpressions;

namespace AdventOfCode2022.Days;

public class Day5
{
    public static void Solve(string inp)
    {
        var r = new Regex(@"move (?<cnt>\d+) from (?<src>\d+) to (?<dst>\d+)", RegexOptions.Compiled);
        var parts = inp.Split("\n\n");
        var actions = r.Matches(parts[1]).ToArray();
        var graph = parts[0].Split('\n').ToList();
        var stacks = new List<List<char>>();
        var last = graph.Last();
        var columnIndexers = new Dictionary<int, int>();
        for (var i = 0; i < last.Length; i++)
        {
            if (char.IsDigit(last[i]))
                columnIndexers.Add(i ,int.Parse($"{last[i]}"));
        }
        graph.RemoveAt(graph.Count - 1);
        var rows = graph.Count;
        foreach (var column in columnIndexers)
        {
            var stack = new List<char>();
            for (var i = rows - 1; i >= 0; i--)
            {
                var item = graph[i].ElementAtOrDefault(column.Key);
                if (char.IsLetter(item))
                    stack.Insert(0, item);
            }
            stacks.Add(stack);
        }

        char[] ExecuteActions(bool shouldReverse = true)
        {
            var st = stacks.ConvertAll(stack => stack.ConvertAll(c => c));
            foreach (var command in actions)
            {
                var groups = command.Groups;
                var cnt = int.Parse(groups["cnt"].Value);
                var src = int.Parse(groups["src"].Value);
                var dst = int.Parse(groups["dst"].Value);
                var srcStack = st[src - 1];
                var destStack = st[dst - 1];
                var toMove = srcStack.Take(Math.Min(cnt, srcStack.Count)).ToArray();
                srcStack.RemoveRange(0, Math.Min(cnt, srcStack.Count));
                destStack.InsertRange(0, shouldReverse ? toMove.Reverse() : toMove);
            }

            return st.Where(f => f.Any()).Select(f => f.First()).ToArray();
        }
        
        Console.WriteLine(ExecuteActions()); // part 1
        Console.WriteLine(ExecuteActions(false)); // part 2
    }
}