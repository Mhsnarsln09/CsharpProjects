using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciAverageApp
{
    public class FibonacciCalculator
    {
        public int[] GenerateSeries(int depth)
        {
             if (depth <= 0)
            {
                throw new ArgumentException("Depth should be a positive integer.");
            }
            int[] fibonacciSeries = new int[depth];
            for (int i = 0; i < depth; i++)
            {
                if (i == 0 || i == 1)
                {
                    fibonacciSeries[i] = i;
                }
                else
                {
                    fibonacciSeries[i] = fibonacciSeries[i - 1] + fibonacciSeries[i - 2];
                }
            }
            return fibonacciSeries;
        }
    }
}