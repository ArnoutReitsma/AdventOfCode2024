Console.WriteLine("Hello, Day1!");
var lines = File.ReadLines(@"..\..\..\input.txt");
Console.WriteLine(TotalDistance(lines));
Console.WriteLine(Similarities(lines));

int TotalDistance(IEnumerable<string> line)
{
    var left = line.Select(l => int.Parse(l.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0].Trim())).Order().ToArray();
    var right = line.Select(l => int.Parse(l.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1].Trim())).Order().ToArray();
    var distance = 0;
    for (int i = 0; i < line.Count(); ++i)
    {
        distance += Math.Abs(left[i] - right[i]);
    }

    return distance;
}

int Similarities(IEnumerable<string> line)
{
    var left = line.Select(l => int.Parse(l.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0].Trim())).Order().ToArray();
    var right = line.Select(l => int.Parse(l.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1].Trim())).Order().ToArray();
    var similarities = 0;
    for (int i = 0; i < line.Count(); ++i)
    {
        similarities += right.Count(r => r == left[i]) * left[i];
    }

    return similarities;
}