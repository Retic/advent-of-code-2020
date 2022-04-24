using day2;

var passwords = File.ReadAllLines("input.txt").ToList();


var policy1Validator = new Policy1Validator();
var policy2Validator = new Policy2Validator();
File.ReadAllLines("input.txt").Select(x => policy1Validator.Validate(x)).Count(); 

Console.WriteLine($"Valid Passwords: {File.ReadAllLines("input.txt").Where(x => policy1Validator.Validate(x)).Count()}");
Console.WriteLine($"Valid Passwords: {File.ReadAllLines("input.txt").Where(x => policy2Validator.Validate(x)).Count()}");
Console.WriteLine($"Valid Passwords: {Solutions.Solve1(passwords)}");
Console.WriteLine($"Valid Passwords: {Solutions.Solve2(passwords)}");


