using System;

namespace ConsonantCheckerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHandler = new InputHandler();
            var consonantChecker = new ConsonantChecker();
            var outputHandler = new OutputHandler();

            string input = inputHandler.GetInput();
            string[] words = input.Split(' ');
            string[] results = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                results[i] = consonantChecker.HasConsecutiveConsonants(words[i]).ToString();
            }

            outputHandler.PrintOutput(results);
        }
    }
}
