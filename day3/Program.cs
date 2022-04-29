using day3;


var slopeService = new ToboggonSlopeService();

var rawData = File.ReadAllText("input.txt");
var slope = slopeService.ParseRawData(rawData);
var part1 = slopeService.FindPath(slope, 3, 1);


//var part2 = slopeService.FindPath(slope, 1, 1);
//var part3 = slopeService.FindPath(slope, 5, 1);
//var part4 = slopeService.FindPath(slope, 7, 1);
//var part5 = slopeService.FindPath(slope, 1, 2);

//var res = part2 * part3 * part4 * part5;



//Right 1, down 1.
//Right 3, down 1. (This is the slope you already checked.)
//Right 5, down 1.
//Right 7, down 1.
//Right 1, down 2.

var part2_1 = slopeService.FindPath(rawData, 1, 1);
var part2_2 = slopeService.FindPath(rawData, 3, 1);
var part2_3 = slopeService.FindPath(rawData, 5, 1);
var part2_4 = slopeService.FindPath(rawData, 7, 1);
var part2_5 = slopeService.FindPath(rawData, 1, 2);

var part2Result = (part2_1 * part2_2 * part2_3 * part2_4 * part2_5);


//var solvedPath = slopeService.PrintSlope(slope);
//var res = solvedPath.Where(x => x == 'X').Count();

