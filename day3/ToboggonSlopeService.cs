namespace day3
{

    public class ToboggonSlopeService
    {
        public string[][] ParseRawData(string rawData)
        {
            return rawData
                .Replace("\r", "")
                .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(r => r.Select(c => c.ToString()).ToArray()).ToArray();
        }

        public string[][] RepeatSlope(int repitition, string[][] slope)
        {
            var rawData = "";

            for (int y = 0; y < slope?.Length; y++)
            {
                var repCount = 0;

                for (int x = 0; x < slope[y].Length * repitition; x++)
                {
                    if (x >= slope[y].Length)
                    {
                        x = 0;
                        repCount++;
                    }
                    rawData += slope[y][x];
                    if (repCount == repitition) break;
                }

                rawData += "\r\n";
            }

            return ParseRawData(rawData);
        }

        public string PrintSlope(string[][] slope)
        {
            var rawData = "";

            for (int y = 0; y < slope?.Length; y++)
            {
                for (int x = 0; x < slope[y].Length; x++)
                {
                    Console.Write($"{slope[y][x]}");
                    rawData += slope[y][x];
                }

                Console.WriteLine();
                rawData += "\r\n";
            }

            return rawData;
        }

        public int FindPath(string[][] slope, int dX, int dY)
        {
            var count = 0;
            var x = 0;

            for (int y = 0; y < slope.Length; y += dY)
            {
                if (slope[y][x] == "#") count++;
                x = (x + dX) % slope[0].Length;
                Console.WriteLine((x + dX) % slope.Length);
            }

            PrintPath(slope, dX, dY);
            return count;
        }

        public void PrintPath(string[][] slope, int dX, int dY)
        {
            var count = 0;
            var x = 0;

            for (int y = 0; y < slope.Length; y += dY)
            {
                if (slope[y][x] == "#")
                {
                    count++;
                    slope[y][x] = "X";
                }
                x = (x + dX) % slope[0].Length;
            }

            PrintSlope(slope);
        }
    }
}
