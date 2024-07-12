namespace TriangleDrawerApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the height of the triangle: ");
        int size = int.Parse(Console.ReadLine());

        TriangleDrawer triangleDrawer = new TriangleDrawer();
        triangleDrawer.DrawTriangle(size);
    }
}
