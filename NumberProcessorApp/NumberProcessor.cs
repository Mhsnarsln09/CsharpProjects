using System;

namespace NumberProcessorApp
{
    public class NumberProcessor
    {
        private const int Threshold = 67;

        public (int, int) ProcessNumbers(int[] numbers)
        {
            int sumOfDifferences = 0;
            int sumOfSquaredDifferences = 0;

            foreach (int number in numbers)
            {
                if (number < Threshold)
                {
                    sumOfDifferences += Threshold - number;
                }
                else if (number > Threshold)
                {
                    sumOfSquaredDifferences += (int)Math.Pow(Threshold - number, 2);
                }
            }

            return (sumOfDifferences, sumOfSquaredDifferences);
        }
    }
}
