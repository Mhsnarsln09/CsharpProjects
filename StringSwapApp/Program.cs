using System;

namespace StringWordSwapApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler inputHandler = new InputHandler();
            string inputString = inputHandler.GetInput();

            StringSwapper stringSwapper = new StringSwapper();

            string[] words = inputString.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = stringSwapper.SwapAdjacentCharacters(words[i]);
            }

            string result = string.Join(' ', words);
            Console.WriteLine(result);
        }
    }
}
