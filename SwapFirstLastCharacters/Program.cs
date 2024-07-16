using System;

namespace SwapFirstLastCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHandler = new InputHandler();
            var stringProcessor = new StringProcessor();
            var outputHandler = new OutputHandler();

            string input = inputHandler.GetInput();
            string output = stringProcessor.ProcessString(input);
            outputHandler.PrintOutput(output);
        }
    }
}
