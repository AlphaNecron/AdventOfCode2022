namespace AdventOfCode2022.Days;

public class Day2
{
    public static void Solve(string inp)
    {
        long pointPart1 = 0, pointPart2 = 0;
        var win = new Dictionary<char, char>
        {
            {'A', 'Y'},
            {'B', 'Z'},
            {'C', 'X'}
        };
        var draw = new Dictionary<char, char>
        {
            {'A', 'X'},
            {'B', 'Y'},
            {'C', 'Z'}
        };
        var lose = new Dictionary<char, char>
        {
            {'A', 'Z'},
            {'B', 'X'},
            {'C', 'Y'}
        };
        var score = new Dictionary<char, byte>
        {
            {'X', 1},
            {'Y', 2},
            {'Z', 3}
        };
        foreach (var round in inp.Split('\n'))
        {
            var x = round.Split(' ').Select(f => f.First()).ToArray();
            char opponent = x[0], you = x[1];
            if (win[opponent] == you)
                pointPart1 += 6 + score[you];
            else if (draw[opponent] == you)
                pointPart1 += 3 + score[you];
            else pointPart1 += score[you];
        }

        foreach (var round in inp.Split('\n'))
        {
            var x = round.Split(' ').Select(f => f.First()).ToArray();
            char opponent = x[0], todo = x[1];
            switch (todo)
            {
                case 'X': // lose
                {
                    pointPart2 += score[lose[opponent]];
                    break;
                }
                case 'Y': // draw
                {
                    pointPart2 += 3;
                    pointPart2 += score[draw[opponent]];
                    break;
                }
                case 'Z': // win
                {
                    pointPart2 += 6;
                    pointPart2 += score[win[opponent]];
                    break;
                }
            }
        }

        Console.WriteLine(pointPart1);
        Console.WriteLine(pointPart2);
    }
}