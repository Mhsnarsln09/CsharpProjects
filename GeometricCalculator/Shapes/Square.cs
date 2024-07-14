
using GeometricCalculator.Shapes;

public class Square : IShape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public double CalculateArea() => Math.Pow(Side, 2);
    public double CalculatePerimeter() => 4 * Side;
    
}