namespace day1
{
    public class Solutions
    {

        //This is Not my Solutiuon... Thanks @Dylan Beattie
        public static int Solve(IEnumerable<int> ints, int targetSum, int numberOfIntsToSum)
        {
            if (numberOfIntsToSum == 0 || !ints.Any()) return 0;
            var head = ints.First();
            var tail = ints.Skip(1);
            if(numberOfIntsToSum == 1 && head == targetSum) return(head);
            var result = head * Solve(tail, targetSum - head, numberOfIntsToSum - 1);
            if(result != 0) return result;
            return Solve(tail, targetSum, numberOfIntsToSum);
        }

        public static int Solve2(List<int> ints)
        {
            for (int i = 0; i < ints.Count; i++)
            {
                for (int j = i + 1; j < ints.Count - 1; j++)
                {
                    for (int k = j + 1; k < ints.Count - 2; k++)
                    {
                        if (ints[i] + ints[j] + ints[k] == 2020)
                            return ints[i] * ints[j] * ints[k];
                    }
                }
            }
            return 0;
        }

        public static int Solve1(List<int> ints)
        {
            for (int i = 0; i < ints.Count; i++)
            {
                for (int j = i + 1; j < ints.Count - 1; j++)
                {
                    if (ints[i] + ints[j] == 2020)
                        return ints[i] * ints[j];
                }
            }
            return 0;
        }
    }
}