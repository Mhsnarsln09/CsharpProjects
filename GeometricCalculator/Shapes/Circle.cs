using GeometricCalculator.Shapes;

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
    public double CalculatePerimeter() => 2 * Math.PI * Radius;
   
}
