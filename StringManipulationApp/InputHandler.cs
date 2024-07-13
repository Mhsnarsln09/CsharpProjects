using System;

namespace StringManipulationApp
{
    public class InputHandler
    {
        public (string, int) GetInput()
        {
            Console.Write("Please enter a string and an index separated by a comma: ");
            string input = Console.ReadLine();

            string[] parts = input.Split(',');

            if (parts.Length != 2 || !int.TryParse(parts[1], out int index))
            {
                Console.WriteLine("Invalid input. Please enter in the format 'string,index'.");
                return ("", -1);
            }

            return (parts[0], index);
        }
    }
}
