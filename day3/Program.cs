using day3;


var slopeService = new ToboggonSlopeService();

var rawData = File.ReadAllText("input.txt");
var slope = slopeService.ParseRawData(rawData);
//var repeatedSlope = slopeService.RepeatSlope(200, slope);
var part1 = slopeService.FindPath(slope, 3, 1);


//var part2 = slopeService.FindPath(slope, 1, 1);
//var part3 = slopeService.FindPath(slope, 5, 1);
//var part4 = slopeService.FindPath(slope, 7, 1);
//var part5 = slopeService.FindPath(slope, 1, 2);

//var res = part2 * part3 * part4 * part5;



//var solvedPath = slopeService.PrintSlope(slope);
//var res = solvedPath.Where(x => x == 'X').Count();

var xT = "";

