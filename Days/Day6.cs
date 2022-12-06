namespace AdventOfCode2022.Days;

public class Day6
{
    public static void Solve(string inp)
    {
        string s;
        bool FindUnique(int len)
        {
            if (s.Length < len) return false;
            var lastChars = s.TakeLast(len).ToArray();
            var freq = lastChars.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
            return freq.All(f => f.Value == 1);
        }

        void FindFirstMarker(int len = 4)
        {
            s = "";
            for (var i = 0; i < inp.Length; i++)
            {
                s += inp[i];
                var p = FindUnique(len);
                if (!p) continue;
                Console.WriteLine(i + 1);
                return;
            }
        }
        // part 1
        FindFirstMarker();
        // part 2
        FindFirstMarker(14);
    }
}