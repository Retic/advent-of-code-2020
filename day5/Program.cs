using day5;

var boardingService = new BoardingPassService();
var data = File.ReadAllLines("input.txt");

var boardingPasses = data.Select(l => boardingService.ParseBoardingPass(l)).ToList();

Console.WriteLine($"Highest Seat Number: {boardingPasses.Max(x => x.SeatId)}");
