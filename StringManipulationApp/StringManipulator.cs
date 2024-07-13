using System;

namespace StringManipulationApp
{
    public class StringManipulator
    {
        public string RemoveCharacterAtIndex(string input, int index)
        {
            if (index < 0 || index >= input.Length)
            {
                Console.WriteLine("Index is out of range.");
                return input;
            }

            return input.Remove(index, 1);
        }
    }
}
