using System;

namespace ConsonantCheckerApp
{
    public class InputHandler
    {
        public string GetInput()
        {
            Console.WriteLine("Enter a string: ");
            return Console.ReadLine();
        }
    }
}