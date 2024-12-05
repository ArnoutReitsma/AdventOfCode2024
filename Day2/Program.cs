// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var lines = File.ReadLines(@"..\..\..\input.txt");
Console.WriteLine("Part 1 " + AmountSafePart1(lines));
Console.WriteLine("Part 2 " + AmountSafePart2(lines));

int AmountSafePart1(IEnumerable<string> lines)
{
    var map = lines.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
    var safe = 0;

    foreach (var levels in map)
    {
        if (!IsSafe(levels))
        {
            continue;
        }

        safe++;
    }

    return safe;
}

bool IsSafe(IEnumerable<int> levels) => IsOrdered(levels) && HasValidLevels(levels);

bool IsOrdered(IEnumerable<int> levels)
{
    var levelArray = levels.ToArray();
    return levelArray.SequenceEqual(levelArray.Order()) ||
           levelArray.SequenceEqual(levelArray.OrderByDescending(x => x));
}

bool HasValidLevels(IEnumerable<int> levels)
{
    var levelArray = levels.ToArray();
    for (int i = 1; i < levelArray.Length; i++)
    {
        int difference = Math.Abs(levelArray[i] - levelArray[i - 1]);
        if (difference > 3 || difference == 0)
        {
            return false;
        }
    }
    return true;
}

int AmountSafePart2(IEnumerable<string> lines)
{
    var map = lines.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)));
    var safe = 0;

    foreach (var levels in map)
    {
        if (!IsSafe(levels))
        {
            for (int i = 0; i <= levels.Count(); i++)
            {
                var considerLevel = levels.Where((_, index) => index != i);
                if (IsSafe(considerLevel))
                {
                    safe++;
                    break;
                }
            }
        } else
        {
            safe++;
        }
    }

    return safe;
}