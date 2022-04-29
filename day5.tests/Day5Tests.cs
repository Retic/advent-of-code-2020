using Xunit;

namespace day5.tests
{
    public class Day5Tests
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void Test_Boarding_Pass(string rawBoardingPass, int row, int column, int seatId)
        {
            var boardingPassService = new BoardingPassService();
            var res = boardingPassService.ParseBoardingPass(rawBoardingPass);

            Assert.True(res.Row == row);
            Assert.True(res.Column == column);
            Assert.True(res.SeatId == seatId);
        }
    }
}