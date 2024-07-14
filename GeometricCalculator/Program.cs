// Program.cs
using System;
using GeometricCalculator.Shapes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select the shape: ");
        Console.WriteLine("1. Circle");
        Console.WriteLine("2. Triangle");
        Console.WriteLine("3. Square");
        Console.WriteLine("4. Rectangle");

        int shapeChoice = int.Parse(Console.ReadLine());

        double[] dimensions;
        switch (shapeChoice)
        {
            case 1:
                Console.WriteLine("Enter the radius of the circle: ");
                dimensions = new double[] { double.Parse(Console.ReadLine()) };
                break;
            case 2:
                Console.WriteLine("Enter the base and height of the triangle (comma-separated): ");
                dimensions = Array.ConvertAll(Console.ReadLine().Split(','), double.Parse);
                break;
            case 3:
                Console.WriteLine("Enter the side length of the square: ");
                dimensions = new double[] { double.Parse(Console.ReadLine()) };
                break;
            case 4:
                Console.WriteLine("Enter the width and height of the rectangle (comma-separated): ");
                dimensions = Array.ConvertAll(Console.ReadLine().Split(','), double.Parse);
                break;
            default:
                throw new ArgumentException("Invalid shape choice");
        }

        IShape shape = ShapeFactory.CreateShape(shapeChoice, dimensions);

        Console.WriteLine("Select the property to calculate: ");
        Console.WriteLine("1. Area");
        Console.WriteLine("2. Perimeter");

        int propertyChoice = int.Parse(Console.ReadLine());

        double result = propertyChoice switch
        {
            1 => shape.CalculateArea(),
            2 => shape.CalculatePerimeter(),
            _ => throw new ArgumentException("Invalid property choice"),
        };

        string property = propertyChoice switch
        {
            1 => "area",
            2 => "perimeter",
            _ => throw new ArgumentException("Invalid property choice"),
        };

        Console.WriteLine($"The {property} of the selected shape is {result}");
    }
}
