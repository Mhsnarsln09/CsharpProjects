using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriangleDrawerApp
{
    public class TriangleDrawer
    {
        public void DrawTriangle(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size should be a positive integer.");
            } else if (size < 3)
            {
                throw new ArgumentException("Size should be at least 3.");
            }

            for (int i = 1; i <= size; i++)
            {
                DrawLine(i, size);
            }
        }

        // Verilen genişlikte bir çizgi çizer
        private void DrawLine(int currentLine, int totalLines)
        {
            int spaces = totalLines - currentLine;
            for (int j = 0; j < spaces; j++)
            {
                Console.Write(" ");
            }
            for (int k = 0; k < currentLine; k++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}