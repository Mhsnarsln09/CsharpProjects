using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciAverageApp
{
    public class AverageCalculator
    {
        public double CalculateAverage(int[] series)
        {
            double sum = 0;
            foreach (int number in series)
            {
                sum += number;
            }
            return sum / series.Length;
        }
    }
}