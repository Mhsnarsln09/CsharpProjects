using System;
using System.Collections.Generic;

public static class PairProcessor
{
    public static void ProcessPairsAndPrintResults(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i += 2)
        {
            if (i + 1 < numbers.Count)
            {
                int num1 = numbers[i];
                int num2 = numbers[i + 1];
                int sum = num1 + num2;
                
                if (num1 == num2)
                {
                    Console.WriteLine(sum * sum);
                }
                else
                {
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
