// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, Day3!");

//var lines = File.ReadLines(@"..\..\..\input-example.txt");
var lines = File.ReadLines(@"..\..\..\input.txt");

Console.WriteLine("Part 1 " + CalculateMultiplicationsPart1(lines));
Console.WriteLine("Part 2 " + CalculateMultiplicationsPart2(lines));

int CalculateMultiplicationsPart1(IEnumerable<string> lines)
{
    var result = 0;
    string pattern = @"mul\(\d+,\d+\)";
    foreach (var line in lines)
    {

        MatchCollection matches = Regex.Matches(line, pattern);

        foreach (Match match in matches)
        {
            result += ParseMulMatch(match);
        }
    }

    return result;

}

int ParseMulMatch(Match mul)
{
    var part1 = mul.Value.Remove(0, 4);
    var l = int.Parse(part1.Split(',')[0]);
    var r = int.Parse(part1.Split(',')[1].Remove(part1.Split(',')[1].Length - 1, 1));
    return l * r;
}


int CalculateMultiplicationsPart2(IEnumerable<string> lines)
{
    var result = 0;
    string pattern = @"mul\(\d+,\d+\)";
    string dontPattern = @"don't\(\)";
    string doPattern = @"do\(\)";
    var doIt = true;
    foreach (var line in lines)
    {
        MatchCollection matches = Regex.Matches(line, pattern);
        MatchCollection doMatches = Regex.Matches(line, doPattern);
        MatchCollection dontMatches = Regex.Matches(line, dontPattern);
        for (int i = 0; i < line.Count(); i++)
        {
            if (doIt && matches.Any(x => x.Index == i))
            {
                result += ParseMulMatch(matches.Single(x => x.Index == i));
            }
            if (doMatches.Any(x => x.Index == i))
            {
                doIt = true;
            }
            if (dontMatches.Any(x => x.Index == i))
            {
                doIt = false;
            }
        }
    }
    return result;

}