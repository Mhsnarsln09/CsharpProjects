using System;
using System.Linq;

namespace NumberProcessorApp
{
    public class InputReader
    {
        public int[] ReadNumbers(string input)
        {
            return input.Split(' ').Select(int.Parse).ToArray();
        }
    }
}
