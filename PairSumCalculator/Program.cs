// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = InputHelper.GetNumbersFromUser();
        PairProcessor.ProcessPairsAndPrintResults(numbers);
    }
}
