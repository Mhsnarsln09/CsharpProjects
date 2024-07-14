
using GeometricCalculator.Shapes;

public class Triangle : IShape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }

    public double CalculateArea() => 0.5 * Base * Height;
    public double CalculatePerimeter() => Base + 2 * Math.Sqrt(Math.Pow(Base / 2, 2) + Math.Pow(Height, 2));

}