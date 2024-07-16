using System;

namespace ConsonantCheckerApp
{
    public class OutputHandler
    {
        public void PrintOutput(string[] results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
