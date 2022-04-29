using day5;

var boardingService = new BoardingPassService();
var data = File.ReadAllLines("input.txt");

var boardingPasses = data.Select(l => boardingService.ParseBoardingPass(l)).ToList().OrderBy(s => s.SeatId);
var seatIds = boardingPasses.Select(bp => bp.SeatId).ToList();

var previousSeatId = 0;

foreach (var seatId in seatIds)
{
  
    if (previousSeatId != 0 && seatId - previousSeatId > 1)
    {
        Console.WriteLine($"Found your Seat: {seatId - 1}");
    }

    previousSeatId = seatId;

}

Console.WriteLine($"Highest Seat Number: {boardingPasses.Max(x => x.SeatId)}");
