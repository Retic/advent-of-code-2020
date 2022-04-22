// See https://aka.ms/new-console-template for more information
var ints = File.ReadAllLines("input.txt").Select(i => int.Parse(i)).ToList();

Console.WriteLine(Solve1(ints));
Console.WriteLine(Solve2(ints));
//Console.WriteLine(SolveDay1(ints, 2, 2020, 0));


// int SolveDay1(List<int> ints, int numberOfintsToSum, int targetProduct, int currentDepth)
// {
  
//    var head = ints.FirstOrDefault();
//    var tail = ints.Skip(1).ToList();

//    if(head == default(int))
//         return 0;

//     //This will solve 2 int sum
//     for (int i = 0; i < tail.Count; i++)
//     {
//         if(head + tail[i] == targetProduct)
//             return head * tail[i];
//     }
    
// }

int Solve2(List<int> ints)
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


int Solve1(List<int> ints)
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
