using day2;

var passwords = File.ReadAllLines("input.txt").ToList();
Console.WriteLine($"Valid Passwords: {Solutions.Solve1(passwords)}");
Console.WriteLine($"Valid Passwords: {Solutions.Solve2(passwords)}");


