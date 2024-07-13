using System;

namespace StringManipulationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler inputHandler = new InputHandler();
            var (inputString, index) = inputHandler.GetInput();

            if (index == -1)
            {
                return;
            }

            StringManipulator stringManipulator = new StringManipulator();
            string result = stringManipulator.RemoveCharacterAtIndex(inputString, index);

            Console.WriteLine(result);
        }
    }
}
