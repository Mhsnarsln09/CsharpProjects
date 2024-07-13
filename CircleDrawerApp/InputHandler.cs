using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CircleDrawerApp
{
    public class InputHandler
    {
        public int GetRadius()
        {
            Console.Write("Please enter the radius of the circle: ");
            string input = Console.ReadLine();
            int radius;

            while (!int.TryParse(input, out radius) || radius <= 0)
            {
                Console.Write("Invalid input. Please enter a positive integer for the radius: ");
                input = Console.ReadLine();
            }

            return radius;
        }
    }
}