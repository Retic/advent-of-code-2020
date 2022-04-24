using day1;

var ints = File.ReadAllLines("input.txt").Select(i => int.Parse(i)).ToList();

Console.WriteLine($"Loop Solve1: {Solutions.Solve1(ints)}");
Console.WriteLine($"Loop Solve2: {Solutions.Solve2(ints)}");
Console.WriteLine($"Recursive Solve All: {Solutions.Solve(ints, 2020, 3)}");