using System.IO;
using Xunit;

namespace day3.tests
{
    public class Day3Tests
    {
        [Fact]
        public void Test_Slope_Parser()
        {
            var data = File.ReadAllText("sampleData.txt");

            var slopeService = new ToboggonSlopeService();

            var slope = slopeService.ParseRawData(data);

            Assert.True(slope.Length == 11);
            Assert.True(slope[0].Length == 11);
        }


        [Fact]
        public void Test_Slope_PathChecker()
        {
            var data = File.ReadAllText("sampleData.txt");

            var slopeService = new ToboggonSlopeService();

            var slope = slopeService.ParseRawData(data);
            var res = slopeService.FindPath(slope, 3, 1);

            Assert.True(res == 7);

        }
    }
}