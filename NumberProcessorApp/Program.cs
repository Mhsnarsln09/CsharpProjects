using System;

namespace NumberProcessorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InputReader inputReader = new InputReader();
            NumberProcessor numberProcessor = new NumberProcessor();
            ResultWriter resultWriter = new ResultWriter();

            Console.WriteLine("Please enter the numbers separated by space:");
            string input = Console.ReadLine();
            
            int[] numbers = inputReader.ReadNumbers(input);
            (int sumOfDifferences, int sumOfSquaredDifferences) = numberProcessor.ProcessNumbers(numbers);
            resultWriter.WriteResults(sumOfDifferences, sumOfSquaredDifferences);
        }
    }
}
