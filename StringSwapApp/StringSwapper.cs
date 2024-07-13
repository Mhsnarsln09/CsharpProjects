using System;
using System.Text;

namespace StringWordSwapApp
{
    public class StringSwapper
    {
        public string SwapAdjacentCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder swappedString = new StringBuilder(input);

            for (int i = 0; i < input.Length - 1; i++)
            {
                char temp = swappedString[i];
                swappedString[i] = swappedString[i + 1];
                swappedString[i + 1] = temp;
            }

            return swappedString.ToString();
        }
    }
}
