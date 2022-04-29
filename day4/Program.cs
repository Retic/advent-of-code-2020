using day4;

var rawData = File.ReadAllText("input.txt");
var passPortService = new PassportService();

var res = passPortService.ParsePassportFromString(rawData);
var validPassports = res.Where(p => passPortService.IsValid(p));
var inValidPasswords = res.Where(p => !passPortService.IsValid(p));


Console.WriteLine(validPassports.Count());

