using System;
using System.Collections.Generic;

public static class InputHelper
{
    public static List<int> GetNumbersFromUser()
    {
        Console.WriteLine("Enter a series of integers separated by spaces:");
        string input = Console.ReadLine();
        
        string[] inputStrings = input.Split(' ');
        List<int> numbers = new List<int>();
        foreach (string str in inputStrings)
        {
            if (int.TryParse(str, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine($"Invalid number: {str}");
            }
        }
        return numbers;
    }
}
