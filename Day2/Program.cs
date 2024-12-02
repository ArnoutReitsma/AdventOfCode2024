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
        if (!IsOrdered(levels) || HasInvalidLevels(levels))
        {
            continue;
        }

        safe++;
    }

    return safe;
}
bool IsOrdered(IEnumerable<int> levels)
{
    var levelArray = levels.ToArray(); // Avoid multiple enumeration
    return levelArray.SequenceEqual(levelArray.Order()) ||
           levelArray.SequenceEqual(levelArray.OrderByDescending(x => x));
}

bool HasInvalidLevels(IEnumerable<int> levels)
{
    var levelArray = levels.ToArray();
    for (int i = 1; i < levelArray.Length; i++)
    {
        int difference = Math.Abs(levelArray[i] - levelArray[i - 1]);
        if (difference > 3 || difference == 0)
        {
            return true;
        }
    }
    return false;
}

int AmountSafePart2(IEnumerable<string> lines)
{
    var map = lines.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)));
    var safe = 0;

    foreach (var levels in map)
    {
        for (int i = 0; i < levels.Count(); i++) {
            var checkLevels = levels;
            if (!IsOrdered(levels) || HasInvalidLevels(levels))
            {
                continue;
            }
        }
        safe++;
    }

    return safe;
}