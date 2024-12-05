// See https://aka.ms/new-console-template for more information

using System.Data;

Console.WriteLine("Hello, Day 5!");

//var lines = File.ReadLines(@"..\..\..\input-example.txt");
var lines = File.ReadLines(@"..\..\..\input.txt");

Console.WriteLine("Part 1 " + SumMiddlePageCorrectPrint(lines));


Console.WriteLine("Part 2 " + SumMiddlePageCorrectPrint(lines.ToArray()));

int SumMiddlePageCorrectPrint(IEnumerable<string> lines)
{
    var sum = 0;
    var pageRules = lines
     .Where(l => l.Contains('|'))
     .Select(l => new Rule(int.Parse(l.Split('|')[0]), int.Parse(l.Split('|')[1])))
     .ToList();

    var updates = lines.Where(l => l.Contains(',')).ToList();

    foreach (var update in updates)
    {
        var pages = update.Split(',').Select(u => int.Parse(u));
        Rule currentRule = null;
        foreach (var page in pages)
        {
            if (currentRule != null)
            {
                currentRule = pageRules.FirstOrDefault(p => p.left == page);
            }
            currentRule = pageRules.FirstOrDefault(p => p.left == page);
        }
    }

    return sum;
}
record Rule(int left, int right);
