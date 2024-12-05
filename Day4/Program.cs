using System.Text.RegularExpressions;

Console.WriteLine("Hello, Day 4!");
//var lines = File.ReadLines(@"..\..\..\input-example.txt");
var lines = File.ReadLines(@"..\..\..\input.txt");

Console.WriteLine("Part 1 " + HowManyXMAS(lines));
Console.WriteLine("Part 2 " + FullHowManyXDashMAS(lines.ToArray()));

int HowManyXMAS(IEnumerable<string> lines)
{
    var result = 0;
    // Horizontal
    foreach (var line in lines)
    {
        result += Regex.Matches(line, "XMAS").Count();
        result += Regex.Matches(line, "SAMX").Count();
    }

    // Vertical
    foreach (var line in PivotStringArray(lines.ToArray()))
    {
        result += Regex.Matches(line, "XMAS").Count();
        result += Regex.Matches(line, "SAMX").Count();
    }
    // Diagonals
    List<string> diagonals = GetDiagonals(lines.ToArray());
    foreach (var diagonal in diagonals)
    {
        result += Regex.Matches(diagonal, "XMAS").Count();
        result += Regex.Matches(diagonal, "SAMX").Count();
    }
    return result;

}

List<string> GetDiagonals(string[] grid)
{
    int rows = grid.Length;
    int cols = grid[0].Length;
    List<string> diagonals = new List<string>();

    // Top-left to bottom-right diagonals
    for (int d = 0; d < rows + cols - 1; d++)
    {
        var diagonal = new List<char>();
        for (int row = 0; row <= d; row++)
        {
            int col = d - row;
            if (row < rows && col < cols)
            {
                diagonal.Add(grid[row][col]);
            }
        }
        diagonals.Add(new string(diagonal.ToArray()));
    }

    // Top-right to bottom-left diagonals
    for (int d = 0; d < rows + cols - 1; d++)
    {
        var diagonal = new List<char>();
        for (int row = 0; row <= d; row++)
        {
            int col = cols - 1 - d + row;
            if (row < rows && col >= 0 && col < cols)
            {
                diagonal.Add(grid[row][col]);
            }
        }
        diagonals.Add(new string(diagonal.ToArray()));
    }

    return diagonals;
}

string[] PivotStringArray(string[] array)
{
    return Enumerable
            .Range(0, lines.Count())
            .Select(i => new string(lines
                .Where(s => i < s.Length)
                .Select(s => s[i])
                .ToArray()))
            .ToArray();
}

int FullHowManyXDashMAS(string[] lines)
{
    var result = 0;
    result += HowManyXDashMAS(lines);

    result += HowManyXDashMAS(PivotStringArray(lines));
    return result;
}

int HowManyXDashMAS(string[] lines)
{
    var result = 0;

    for (int y = 0; y < lines.Count(); y++)
    {
        for (int x = 0; x < lines[y].Count(); x++)
        {
            if (lines[y][x] == 'A')
            {
                void CheckXDashMas(char first, char second)
                {
                    // CHECK TOP LEFT
                    if ((y - 1 >= 0 && x - 1 >= 0) && lines[y - 1][x - 1] == first)
                    {
                        // CHECK BOTTOM LEFT
                        if ((y + 1 < lines.Count() && x - 1 >= 0) && lines[y + 1][x - 1] == first)
                        {
                            // CHECK TOP RIGHT
                            if ((y - 1 >= 0 && x + 1 < lines[y].Count()) && lines[y - 1][x + 1] == second)
                            {
                                // CHECK BOTTOM RIGHT
                                if ((y + 1 < lines.Count() && x + 1 < lines[y].Count()) && lines[y + 1][x + 1] == second)
                                {
                                    result++;
                                }
                            }
                        }
                    }
                }
                CheckXDashMas('M', 'S');
                CheckXDashMas('S', 'M');
            }
        }
    }
    return result;
}