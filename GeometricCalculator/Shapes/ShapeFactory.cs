// ShapeFactory.cs
using GeometricCalculator.Shapes;

public static class ShapeFactory
{
    public static IShape CreateShape(int shapeChoice, double[] dimensions)
    {
        return shapeChoice switch
        {
            1 => new Circle(dimensions[0]),
            2 => new Triangle(dimensions[0], dimensions[1]),
            3 => new Square(dimensions[0]),
            4 => new Rectangle(dimensions[0], dimensions[1]),
            // Diğer şekilleri buraya ekleyin
            _ => throw new ArgumentException("Invalid shape choice"),
        };
    }
}
