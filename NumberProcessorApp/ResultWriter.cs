using System;

namespace NumberProcessorApp
{
    public class ResultWriter
    {
        public void WriteResults(int sumOfDifferences, int sumOfSquaredDifferences)
        {
            Console.WriteLine($"Sum of differences for numbers less than 67: {sumOfDifferences}");
            Console.WriteLine($"Sum of squared differences for numbers greater than 67: {sumOfSquaredDifferences}");
        }
    }
}
